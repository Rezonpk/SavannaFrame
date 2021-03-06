﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SavannaFrame.Classes;

namespace SavannaFrame
{
    /// <summary>
    /// Класс, отвечающий за отображение игрового поля.
    /// </summary>
    public partial class GameField : UserControl
    {
        private int rowCount=10;
        private int columnCount=10;
        private int cellSize = 50; //размер одной клетки
        private int cellOffset = 1; //отсутп между клетками на поле (чтобы было видно границу)

        private List<List<GameCell>> cells;

        /// <summary>
        /// Число ячеек по вертикали на игровом поле. !ВАЖНО: при задании значения игровое поле обнуляется.
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.rowCount;
            }
            set
            {
                this.setSize(value, this.ColumnCount);
            }
        }

        /// <summary>
        /// Число ячеек по горизонтали на игровом поле. !ВАЖНО: при задании значения игровое поле обнуляется.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return this.columnCount;
            }
            set
            {
                this.setSize(this.RowCount, value);
            }
        }

        /// <summary>
        /// Размер одной ячейки игрового поля.
        /// </summary>
        public int CellSize
        {
            get
            {
                return this.cellSize;
            }
            set
            {
                //Не знаю, поможет ли, но задумка такая: 
                //если мы увеличиваем размер ячеек, то вначале ресайзим ячейки, а потом их передвигаем
                //иначе - в обратном порядке. В теории, при нулевом cellOffset должно избавить от мерцания полосок между ячейками.
                if (this.cellSize < value)
                {
                    this.cellSize = value;

                    this.SuspendLayout();
                    foreach (GameCell cell in this.Controls)
                        cell.Size = cellSize;
                    this.ResumeLayout();

                    this.layoutCells();                    
                }
                else
                {
                    this.cellSize = value;    
                
                    this.layoutCells();

                    this.SuspendLayout();
                    foreach (GameCell cell in this.Controls)
                        cell.Size = cellSize;
                    this.ResumeLayout();                    
                }
                

                
            }
        }

        /// <summary>
        /// Отступ между ячейками поля.
        /// </summary>
        public int CellOffset
        {
            get
            {
                return this.cellOffset;
            }
            set
            {
                this.cellOffset = value;
                this.layoutCells();
            }
        }

        /// <summary>
        /// Размещает ячейки внутри контрола в соответствии с их порядком, размером и отступом между ними.
        /// </summary>
        private void layoutCells()
        {
            int xCoord, yCoord = 0;
            this.SuspendLayout();
            for (int i = 0; i < RowCount; ++i)
            {
                xCoord = 0;
                List<GameCell> row = cells[i];
                for (int j = 0; j < ColumnCount; ++j)
                {
                    GameCell cell = row[j];
                    cell.Location = new Point(xCoord, yCoord);
                    xCoord += cellSize + cellOffset;

                }
                yCoord += cellSize + cellOffset;
            }
            this.ResumeLayout();
        }

        public event GameCellClickedEventHandler GameCellClickedEvent;

        /// <summary>
        /// Задает размер поля (в ячейках) по вертикали и горизонтали. !ВАЖНО: игровое поле создается заново! Все данные о ячейках стираются!
        /// </summary>
        /// <param name="rowCount">Число ячеек по вертикали (число рядов)</param>
        /// <param name="columnCount">Число ячеек по горизонтали (число столбцов)</param>
        public void setSize(int rowCount, int columnCount)
        {
            if (rowCount < 1 || columnCount < 1)
                throw new ArgumentException("Row and column counts have to be more than zero! size: (rc:"+rowCount.ToString()+" cc:"+columnCount.ToString()+")");
            cells = new List<List<GameCell>>(rowCount);
            //int xCoord = 0, yCoord = 0;
            this.SuspendLayout();
            this.Controls.Clear();
            for (int i = 0; i < RowCount; ++i)
            {
                //xCoord = 0;
                List<GameCell> row = new List<GameCell>(columnCount);
                for (int j = 0; j < ColumnCount; ++j)
                {
                    Frame framePrototype = new Frame();
                    framePrototype.FrameId = -1;
                    Slot slotImage = new Slot();
                    slotImage.SlotName = "image";
                    slotImage.SlotInheritance = SlotInherit.Override;
                    slotImage.SlotType = SlotType.String;
                    slotImage.SlotDefault = "Images\\unknown.png";
                    slotImage.SlotId = 0;
                    slotImage.ParentId = framePrototype.FrameId;

                    Slot slotRow = new Slot();
                    slotRow.SlotName = "Row";
                    slotRow.SlotType = SlotType.Integer;
                    slotRow.SlotInheritance = SlotInherit.Override;
                    slotRow.SlotId = 1;
                    slotRow.ParentId = framePrototype.FrameId;

                    Slot slotColumn = new Slot();
                    slotColumn.SlotName = "Column";
                    slotColumn.SlotType = SlotType.Integer;
                    slotColumn.SlotInheritance = SlotInherit.Override;
                    slotColumn.SlotId = 1;
                    slotColumn.ParentId = framePrototype.FrameId;

                    framePrototype.FrameSlots.Add(slotImage);
                    framePrototype.FrameSlots.Add(slotRow);
                    framePrototype.FrameSlots.Add(slotColumn);
                    FrameExample frameExample = new FrameExample(framePrototype);
                    frameExample.SetValue("image", "Images\\grass.jpg");

                    frameExample.SetValue("Row", i);
                    frameExample.SetValue("Column", j);

                    GameCell cell = new GameCell(this, i, j, cellSize, frameExample);
                    cell.GameCellClicked += new GameCellClickedEventHandler(cell_GameCellClicked);
                    row.Add(cell);
                    //cell.Location = new Point(xCoord, yCoord);
                    this.Controls.Add(cell);
                    //xCoord += cellSize+cellOffset;
                }
                cells.Add(row);
                //yCoord += cellSize+cellOffset;
            }

            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.ResumeLayout();
            this.layoutCells();
        }

        void cell_GameCellClicked(object sender, GameCellClickedEventArgs args)
        {
            this.GameCellClickedEvent(this, args);
        }

        public GameField()
        {
            InitializeComponent();
            this.setSize(this.rowCount, this.columnCount); //значения по умолчанию у нас заданы, теперь нужно проинициализировать поле этими значениями.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowsCount">Число ячеек по вертикали (число рядов)</param>
        /// <param name="columnsCount">Число ячеек по горизонтали (число столбцов)</param>
        public GameField(int rowsCount, int columnsCount)
        {
            InitializeComponent();
            this.setSize(rowsCount, columnsCount);
        }
    }

    public class GameCellClickedEventArgs
    {
        public GameCell GameCell
        {
            get;
            private set;
        }
        public GameCellClickedEventArgs(GameCell gameCell)
        {
            this.GameCell = gameCell;
        }
    }

    public delegate void GameCellClickedEventHandler(object sender, GameCellClickedEventArgs args);

    /// <summary>
    /// Класс, отвечающий за отображение одной ячейки игрового поля.
    /// </summary>
    public class GameCell : Panel
    {
        private int column, row;
        private GameField gameField;
        //Раньше наследовали от pictureBox'а просто, но он не поддерживает нормальный drag&drop :(приходится так, с костылями. 
        //Сам контрол - панель, а на нем - pictureBox с нужной картинкой.
        PictureBox pictureBox;

        FrameExample frameExample;

        public event GameCellClickedEventHandler GameCellClicked;

        public FrameExample FrameExample
        {
            get
            {
                return this.frameExample;
            }
            private set
            {
                this.frameExample = value;
            }
        }

        public void PerformMLV()
        {

        }

        /// <summary>
        /// Индекс строки ячейки на игровом поле
        /// </summary>
        public int Row { 
            get { return row; }
            private set { row = value; }
        }
        
        /// <summary>
        /// Индекс столбца ячейки на игровом поле
        /// </summary>
        public int Column {
            get { return column; }
            private set { column = value; }
        }

        /// <summary>
        /// Размер ячейки в пикселях
        /// </summary>
        public new int Size
        {
            get
            {
                return base.Size.Width;
            }
            set
            {
                this.SuspendLayout();
                base.Size = new Size(value, value);
                this.ResumeLayout();
            }
        }
        /// <summary>
        /// Игровое поле, которому принадлежит ячейка.
        /// </summary>
        public GameField GameField { get { return gameField; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameField">Игровое поле, которому принадлежит ячейка.</param>
        /// <param name="x">Индекс ряда ячейки на игровом поле.</param>
        /// <param name="y">Индекс столбца ячейки на игровом поле.</param>
        /// <param name="size">Размер ячейки (в пикселях).</param>
        public GameCell(GameField gameField, int row, int column, int size, FrameExample frameExample = null) : base()
        {
            this.FrameExample = frameExample;

            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            this.Controls.Add(pictureBox);
            this.AllowDrop = true;

            this.gameField = gameField;
            this.Size = size;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            String imageFile;
            if (frameExample != null)
            {
                //Фрейм-прототип этого экземпляра должен быть унаследован от фрейма-объекта, который должен содержать слот "image".
                imageFile = (string)frameExample.Value("image");
                if (imageFile == null)
                    throw new NullReferenceException("slot 'image' not found for frame " + frameExample.BaseFrame.FrameName + " with id " + frameExample.BaseFrame.FrameId.ToString());
            }
            else
            {
                imageFile = "Images\\grass.jpg";
            }
            pictureBox.Image = Image.FromFile(imageFile);

            this.Row = row;
            this.Column = column;
            this.DragEnter += new DragEventHandler(GameCell_DragEnter);
            this.DragDrop += new DragEventHandler(GameCell_DragDrop);
            pictureBox.Click += new EventHandler(pictureBox_Click);
        }

        void pictureBox_Click(object sender, EventArgs e)
        {
            this.GameCellClicked(this, new GameCellClickedEventArgs(this));
        }

        /// <summary>
        /// Срабатывает, когда мышка в режиме Drag&drop входит в пределы контрола. Тут нужно проверить, перетаскивает ли она то, что мы можем обработать,
        /// и если да, то выставить нужный режим drag&drop'а.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GameCell_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem))) //пока будет так
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// Срабатывает, когда пользователь сбрасывает что-то в контрол. Важно: абы что сбросить не получится (см. GameCell_DragEnter).
        /// Собственно, обрабатываем это событие.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GameCell_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            Frame draggedFrame = KnowLedgeBase.getFrameByName(draggedItem.Text);
            this.FrameExample = new FrameExample(draggedFrame);
            this.FrameExample.SetValue("Row", this.Row);
            this.FrameExample.SetValue("Column", this.Column);

            KnowLedgeBase.FramesExamples.Remove(KnowLedgeBase.FramesExamples.Find(f => (Int32.Parse(f.Value("Row").ToString()) == this.Row && Int32.Parse(f.Value("Column").ToString()) == this.Column)));
            KnowLedgeBase.FramesExamples.Add(this.FrameExample);

            this.pictureBox.Image = draggedItem.ImageList.Images[draggedItem.ImageKey];
        }
    }
}
