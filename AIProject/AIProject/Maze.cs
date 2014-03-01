using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    public class Maze
    {
        public char[,] maze { get; set; }
        private int size;
        private Cell startCell=null;
        public List<Cell> path;

        public int Size
        {
            get {return this.size;}
            set {
                if(value>0)
                {
                    this.size=value;
                }
                else
                {
                    this.size=0;
                }
            }
        }

        public Cell StartCell
        {
            get {Cell c=new Cell(this.startCell);
                return c;
            }

            set{
                if(value!=null)
                {
                    this.startCell=new Cell(value);
                }
                else
                {
                    this.startCell=new Cell();
                }
            }
        }

        public Maze(int size,int startCellRow,int startCellColumn)
        {
            this.Size = size;
            this.maze = new char[this.size, this.size];
            this.startCell=new Cell(startCellRow,startCellColumn,0);
            this.maze[startCellRow,startCellColumn]='*';
            this.path = new List<Cell>();
        }
 
        public void PrintMaze()
        {
            for (int i = 0; i < this.maze.GetLength(0); i++)
            {
                for (int j = 0; j < this.maze.GetLength(1); j++)
                {
                    Console.Write("{0} ", this.maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void MakeMaze()
        {
            Random rand = new Random();
            int num;

            for (int i = 0; i < this.maze.GetLength(0); i++)
            {
                for (int j = 0; j < this.maze.GetLength(1);j++)
                {
                    num = rand.Next(0, 2);
                    if (this.maze[i, j] != '*')
                    {
                        if (num == 1)
                        {
                            this.maze[i, j] = 'o';
                        }
                        else
                        {
                            this.maze[i, j] = 'x';
                        }
                    }
                }
            }
        }

        private void VisitedCell(Queue<Cell> visitedCells, int row, int column, int distance,Cell parent)
        {
            if (this.maze[row, column] != 'x' && this.maze[row,column]!='v') //'v' marks visited cells
            {
                this.maze[row, column] = 'v';
                Cell cell = new Cell(row, column, distance);
                cell.AddParent(parent);
                visitedCells.Enqueue(cell);
            }
        }
        private List<Cell> getPath(Cell c)
        {
            List<Cell> path=new List<Cell>();
            Cell currentCell = c;

            while (currentCell.parentCell != null)
            {
                path.Add(currentCell.parentCell);
                currentCell = currentCell.parentCell;
            }

            return path;
        }
        private void GetSolveMazePath()
        {
            foreach (Cell c in this.path)
            {

                for (int i = 0; i < this.maze.GetLength(0); i++)
                {
                    for (int j = 0; j < this.maze.GetLength(1); j++)
                    {
                        if(this.maze[i,j]=='v')//mark visited cells to original "free" cell
                        {
                            this.maze[i,j]='o';
                        }
                          
                        if (c.Row == i && c.Column == j)//mark path
                        {
                            this.maze[i, j] = '#';
                        }
                    }
                }
            }
        }
        public int FindShortestPath()
        {

            if (this.startCell == null)
            {
                return -1;
            }

            Queue<Cell> visitedCells = new Queue<Cell>();
            VisitedCell(visitedCells, this.startCell.Row, this.startCell.Column, 0,null);

            while (visitedCells.Count > 0)
            {
                Cell currentCell = visitedCells.Dequeue();
                int row = currentCell.Row;
                int column = currentCell.Column;
                int distance = currentCell.Distance;
                if ((row == 0) || (row == this.size - 1) || (column == 0) || (column == this.size - 1))
                {
                    this.path.Add(currentCell);
                    this.path.AddRange(getPath(currentCell));
                    GetSolveMazePath();                               //mark path
                    return distance + 1;
                }
                VisitedCell(visitedCells,row, column + 1, distance + 1,currentCell);
                VisitedCell(visitedCells, row, column - 1, distance + 1, currentCell);
                VisitedCell(visitedCells, row + 1, column, distance + 1, currentCell);
                VisitedCell(visitedCells, row - 1, column, distance + 1, currentCell);
            }

            return -1;
        }

      


    }
}
