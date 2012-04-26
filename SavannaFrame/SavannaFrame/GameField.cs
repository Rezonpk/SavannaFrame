using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                    GameCell cell = new GameCell(this, i, j, cellSize);
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

    /// <summary>
    /// Класс, отвечающий за отображение одной ячейки игрового поля.
    /// </summary>
    public class GameCell : Panel
    {
        private int x, y;
        private GameField gameField;
        //Раньше наследовали от pictureBox'а просто, но он не поддерживает нормальный drag&drop :(приходится так, с костылями. 
        //Сам контрол - панель, а на нем - pictureBox с нужной картинкой.
        PictureBox pictureBox; 
 
        
        /// <summary>
        /// Индекс строки ячейки на игровом поле
        /// </summary>
        public int X { get { return x; } }
        /// <summary>
        /// Индекс столбца ячейки на игровом поле
        /// </summary>
        public int Y { get { return y; } }
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
        public GameCell(GameField gameField, int x, int y, int size) : base()
        {
            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            this.Controls.Add(pictureBox);
            this.AllowDrop = true;


            this.gameField = gameField;
            this.Size = size;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Image.FromFile("Images\\grass.jpg"); //пусть пока будет так :) Значение по умолчанию - трава.
            this.x = x;
            this.y = y;
            this.DragEnter += new DragEventHandler(GameCell_DragEnter);
            this.DragDrop += new DragEventHandler(GameCell_DragDrop);
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
            this.pictureBox.Image = draggedItem.ImageList.Images[draggedItem.ImageKey];
        }
    }
}
