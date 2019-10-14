using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Linq;

namespace Gomoku.Models
{
    public class Board
    {
        Spot[,] Spots;
        int RowCount;
        int ColCount;
        public Board(int row, int col)
        {
            Spots = new Spot[row, col];
            RowCount = row;
            ColCount = col;
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                {
                    Spots[i, j] = new Spot(i, j, SpotValue.Empty);
                }
        }

        public bool PlaceChess(int row, int col, SpotValue value)
        {
            if (row < 0 || row >= RowCount || col < 0 || col >= ColCount)
            {
                Console.WriteLine($"{row},{col} is a invalid postion to place chess.");
                return false;
            }
            if (Spots[row, col].Value != SpotValue.Empty)
            {
                Console.WriteLine($"{row},{col} is occupied!");
                return false;
            }
            Spots[row, col].Value = value;
            Console.WriteLine($"{row},{col} is placed a chess {value.ToString()}.");
            return true;
        }

        public bool VerifyBoard(int row, int col)
        {
            return VerifyCol(row, col) || VerifyRow(row, col) || VerifyTiltDown(row, col) || VerifyTiltUp(row, col);
        }

        private bool VerifyCol(int row, int col)
        {
            int count = 1;
            SpotValue value = Spots[row, col].Value;
            int curPosition = row - 1;
            while (curPosition >= 0)
            {
                if (Spots[curPosition, col].Value == value)
                    count++;
                else
                    break;
                curPosition--;
            }
            curPosition = row + 1;
            while (curPosition < RowCount)
            {
                if (Spots[curPosition, col].Value == value)
                    count++;
                else
                    break;
                curPosition++;
            }
            return count >= 5;
        }

        private bool VerifyRow(int row, int col)
        {
            int count = 1;
            SpotValue value = Spots[row, col].Value;
            int curPosition = col - 1;
            while (curPosition >= 0)
            {
                if (Spots[row, curPosition].Value == value)
                    count++;
                else
                    break;
                curPosition--;
            }
            curPosition = col + 1;
            while (curPosition < RowCount)
            {
                if (Spots[row, curPosition].Value == value)
                    count++;
                else
                    break;
                curPosition++;
            }
            return count >= 5;
        }

        private bool VerifyTiltDown(int row, int col)
        {
            int count = 1;
            SpotValue value = Spots[row, col].Value;
            int curRow = row - 1;
            int curCol = col - 1;
            while (curRow >= 0 && curCol >= 0)
            {
                if (Spots[curRow, curCol].Value == value)
                    count++;
                else
                    break;
                curRow--;
                curCol--;
            }
            curRow = row + 1;
            curCol = col + 1;
            while (curRow < RowCount && curCol < ColCount)
            {
                if (Spots[curRow, curCol].Value == value)
                    count++;
                else
                    break;
                curRow++;
                curCol++;
            }
            return count >= 5;
        }

        private bool VerifyTiltUp(int row, int col)
        {
            int count = 1;
            SpotValue value = Spots[row, col].Value;
            int curRow = row + 1;
            int curCol = col - 1;
            while (curRow < RowCount && curCol >= 0)
            {
                if (Spots[curRow, curCol].Value == value)
                    count++;
                else
                    break;
                curRow++;
                curCol--;
            }
            curRow = row - 1;
            curCol = col + 1;
            while (curRow >= 0 && curCol < ColCount)
            {
                if (Spots[curRow, curCol].Value == value)
                    count++;
                else
                    break;
                curRow--;
                curCol++;
            }
            return count >= 5;
        }

        public void Print()
        {
            int rowCount = RowCount;
            PrintLine();
            while (rowCount > 0)
            {
                PrintRow(RowCount - rowCount);
                PrintLine();
                rowCount--;
            }
        }

        private void PrintRow(int row)
        {
            for (int col = 0; col < ColCount; col++)
            {
                Console.Write("|");
                switch (Spots[row, col].Value)
                {
                    case SpotValue.Black:
                        Console.Write("B");
                        break;
                    case SpotValue.White:
                        Console.Write("W");
                        break;
                    default:
                        Console.Write(" ");
                        break;
                }
            }
            Console.Write("|\n");
        }

        private void PrintLine()
        {
            int count = ColCount * 2 + 1;
            while(count-- > 0)
                Console.Write("-");
            Console.Write("\n");
        }
    }
}
