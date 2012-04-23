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

        public void setSize(int rowCount, int columnCount)
        {
            if (rowCount < 1 || columnCount < 1)
                throw new ArgumentException("Row and column counts have to be more than zero! size: (rc:"+rowCount.ToString()+" cc:"+columnCount.ToString()+")");

            this.rowCount = rowCount;
            this.columnCount = columnCount;
        }

        public GameField()
        {
            InitializeComponent();
        }

        private void GameField_Load(object sender, EventArgs e)
        {

        }
    }

    public class GameCell : PictureBox
    {

    }
}
