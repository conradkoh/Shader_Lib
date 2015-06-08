using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shader_Lib
{
    public class Player
    {
        int[] _position;
        int[] _dimensions;
        int[,] _mapGrid;
        List<int[]> objectCoordinates = new List<int[]>();

        //Shader
        int _viewRadius;
        int[,] _shaderGrid;

        public Player(int[,] mapGrid, int[] dimensions)
        {
            _mapGrid = mapGrid;
            _position = new int[2]{0, 0};
            _dimensions = dimensions; //ASSUMPTION: DIMENSIONS FOR SHADER AND MAP SAME
            _viewRadius = dimensions[0] / 2; //ASSUMPTION: SAME X AND Y DIM
            _shaderGrid = new int[dimensions[0], dimensions[1]];
            InitializeGrid(_shaderGrid, dimensions, 0);

        }

        void InitializeGrid(int[,] array, int[] dimensions, int initVal)
        {
            int size = _dimensions.Count();
            if (size == 2)
            {
                int xDimensions = _dimensions[0];
                int yDimensions = _dimensions[1];

                for (int i = 0; i < xDimensions; i++)
                {
                    for (int j = 0; j < yDimensions; j++)
                    {
                        array[i, j] = initVal;
                    }
                }
            }
        }

        public void SetViewRadius(int radius)
        {
            _viewRadius = radius;
        }

        public int[,] GetShaderGrid()
        {
            RenderShaderGrid();
            return _shaderGrid;
            
        }

        void RenderShaderGrid()
        {
            RenderPlayerRadius();
            RenderLineOfSight();

        }
        void RenderPlayerRadius()
        {
            
            for (int curRadius = 0; curRadius < _viewRadius; curRadius++)
            {
                double angle = 0;
                while (angle < (Math.PI * 2))
                {
                    int x_coordinate = (int)Math.Floor(curRadius * Math.Cos(angle)) + _dimensions[0] / 2;
                    int y_coordinate = (int)Math.Floor(curRadius * Math.Sin(angle)) + _dimensions[1] / 2;
                    angle = angle + (Math.PI * 2 / 1000);
                    if (x_coordinate > 0 && y_coordinate > 0)
                    {
                        if (x_coordinate < _dimensions[0] && y_coordinate < _dimensions[1])
                        {
                            _shaderGrid[x_coordinate, y_coordinate] = 1;
                        }
                    }

                }
            }
        }
        void RenderLineOfSight()
        {
            int[] objectTestCoord = new int[2]{10, 10};
            int[] lineVector = GetVector(_position, objectTestCoord);
            for (int i = 0; i < _viewRadius; i++)
            {
                //INCOMPLETE
            }

        }

        int[] GetVector(int[] pointA, int[] pointB)
        {
            int dim = pointA.Count();
            int[] output = new int[dim];
            
            if (pointA.Count() == pointB.Count())
            {
                for (int i = 0; i < dim; i++)
                {
                    output[i] = pointB[i] - pointA[i];
                }
            }

            return output;
        }
    }
}
