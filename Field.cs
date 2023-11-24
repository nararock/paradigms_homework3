using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Field
    {
        string[,] field;
        int size;
        public Field(int size)
        {
            field = new string[size, size];
            int count = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = count.ToString();
                    count++;
                }
            }

            this.size = size; 
        }
        public void enterFigure(double position, string? figure)
        {
            if (position < 1 || position > 9)
            {
                Console.WriteLine($"Вы ввели неверное значение для позиции {figure}");
            }
            else
            {
                int row, col;
                (row, col) = getPosition(position);
                if (!field[row, col].Equals("x") && !field[row, col].Equals("0"))
                {
                    field[row, col] = figure;
                }
            }
            
        }

        private (int, int) getPosition(double position)
        {
            int row = 0, col = 0;
            if (position / 3 <= 1)
            {
                row = 0;
                col = (int)position - 1;
            }
            else if (position / 3 > 1 && position / 3 <= 2)
            {
                row = 1;
                col = (int)position - 4;
            }
            else
            {
                row = 2;
                col = (int)position - 7;
            }
            return (row, col);
        }

        public bool checkWin(double position, string? figure)
        {
            bool flagRow = true, flagCol = true, flagDiagRight = true, flagDiagLeft = true;
            int row, col;
            (row, col) = getPosition(position);
            for (int i = 0; i < size; i++)
            {
                if (!field[row, i].Equals(figure))
                {
                    flagRow = false;
                    break;
                }
            }
            for (int j = 0; j < size; j++)
            {
                if (!field[j, col].Equals(figure))
                {
                    flagCol = false;
                    break;
                }
            }
            for (int d = 0; d < size; d++)
            {
                if (!field[d, d].Equals(figure))
                {
                    flagDiagRight = false;
                    break;
                }
            }
            for (int m = 0, n = size - 1; m < size; m++, n--)
            {
                if (!field[m, n].Equals(figure))
                {
                    flagDiagLeft = false;
                    break;
                }
            }
            return flagRow || flagCol || flagDiagRight || flagDiagLeft;
        }

        public void consoleFigure()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                    Console.Write(" | ");
                }
                var result = string.Join("", Enumerable.Repeat('-', size * 4));
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }
    }
}
