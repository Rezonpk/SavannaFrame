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
    public partial class GameField : UserControl
    {

        int rowCount=10;
        int columnCount=10;

        private int cellSize = 50; //размер одной клетки
        private int cellOffset = 1; //отсутп между клетками на поле (чтобы было видно границу)

        private List<List<GameCell>> cells;

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

        public int CellSize
        {
            get
            {
                return this.cellSize;
            }
            set
            {
                this.cellSize = value;
                this.SuspendLayout();
                foreach (GameCell cell in this.Controls)
                    cell.Size = cellSize;
                this.ResumeLayout();
                this.layoutCells();
                
            }
        }

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

        public void layoutCells()
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

        public GameField(int rowsCount, int columnsCount)
        {
            InitializeComponent();
            this.setSize(rowsCount, columnsCount);
        }

        private void GameField_Load(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class GameCell : PictureBox
    {
        private int x, y;
        private GameField gameField;
        
        public int X { get { return x; } }
        public int Y { get { return y; } }
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
        public GameField GameField { get { return gameField; } }

        public GameCell(GameField gameField, int x, int y, int size) : base()
        {
            this.gameField = gameField;
            this.Size = size;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile("Images\\zebra.jpg");
            this.x = x;
            this.y = y;
        }


    }
}
