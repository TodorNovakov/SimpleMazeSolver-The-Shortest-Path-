using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class Cell
    {
        private int row;
        private int column;
        private int distance;
        public Cell parentCell { get; set; }

        public int Row
        {
            get { return this.row; }
            set
            {
                if (value >= 0)
                {
                    this.row = value;
                }
                else
                {
                    this.row = 0;
                }
            }
        }

        public int Column
        {
            get { return this.column; }
            set
            {
                if (value >= 0)
                {
                    this.column = value;
                }
                else
                {
                    this.column = 0;
                }
            }
        }

        public int Distance
        {
            get { return this.distance; }
            set
            {
                if (value >= 0)
                {
                    this.distance = value;
                }
                else
                {
                    this.distance = 0;
                }
            }
        }

        public Cell(int row, int column, int distance)
        {
            this.Row = row;
            this.Column = column;
            this.Distance = distance;
            this.parentCell = null;
        }

        public Cell()
            : this(0, 0, 0)
        { }

        public Cell(Cell c)
            : this(c.row, c.column, c.distance)
        { }

        public void AddParent(Cell c)
        {
            this.parentCell = c;
        }


        public override string ToString()
        {
            return String.Format("Position row:{0} column:{1} distance:{2}", this.row, this.column, this.distance);
        }
   
    }
}
