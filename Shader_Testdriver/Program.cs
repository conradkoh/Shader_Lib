using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shader_Lib;
namespace Shader_Testdriver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = new int[2];
            dimensions[0] = 30;
            dimensions[1] = 30;
            int[,] mapGrid = new int[dimensions[0], dimensions[1]];
            
            InitializeGrid(ref mapGrid, dimensions, 1);
            //PrintGrid(mapGrid, dimensions);
            int[] treePos = new int[2]{1, 2};
            SetObjectPosition(ref mapGrid, treePos, dimensions, 7);
            Player player = new Player(mapGrid, dimensions);
            int radius = 0;
            while (radius < 100)
            {
                player.SetViewRadius(radius);
                ++radius;
                int[,] playerView = player.GetShaderGrid();
                PrintGrid(playerView, dimensions);
                System.Threading.Thread.Sleep(500);
                
            }
            Console.ReadKey();
        }

        static void InitializeGrid(ref int[,] array, int[] dimensions, int initVal)
        {
            int size = dimensions.Count();
            if (size == 2)
            {
                int xDimensions = dimensions[0];
                int yDimensions = dimensions[1];

                for (int i = 0; i < xDimensions; i++)
                {
                    for (int j = 0; j < yDimensions; j++)
                    {
                        array[i, j] = initVal;
                    }
                }
            }
        }

        static void PrintGrid(int[,] array, int[] dimensions){
           int size = dimensions.Count();
            if (size == 2)
            {
                int xDimensions = dimensions[0];
                int yDimensions = dimensions[1];

                for (int i = 0; i < xDimensions; i++)
                {
                    string line = "";
                    for (int j = 0; j < yDimensions; j++)
                    {
                        line += array[i, j];
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
            }
        }

        static void SetObjectPosition(ref int[,] mapGrid, int[] position, int[] dimensions, int objectValue)
        {
            if (position.Count() == 2 && dimensions.Count() == 2)
            {
                if (position[0] > 0 && position[1] > 0)
                {
                    if (position[0] < dimensions[0] && position[1] < dimensions[1])
                    {
                        int x = position[0];
                        int y = position[1];
                        
                        mapGrid[x,y] = objectValue;
                    }
                }
            }
        }
    }
}