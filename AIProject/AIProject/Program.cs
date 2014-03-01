using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze myMaze = new Maze(20, 13, 15);

            //start maze
            myMaze.MakeMaze();
            myMaze.PrintMaze();
            Console.WriteLine();

            //find the shortest path
            int res=myMaze.FindShortestPath();
            Console.WriteLine(res);

            if (res != -1)
            {
                myMaze.PrintMaze();
            }
            else
            {
                Console.WriteLine("No path");
            }

            if (myMaze.path.Count > 0)
            {
                foreach (Cell c in myMaze.path)
                {
                    Console.WriteLine(c);
                }
            }
            else
            {
                Console.WriteLine("No path");
            }



        }
    }
}
