using System;
using System.Collections.Generic;
using System.Text;

namespace Gomoku.Models
{
    public class Spot
    {
        public int Row;
        public int Col;
        public SpotValue Value { get; set; }
        public Spot(int row, int col, SpotValue spotValue)
        {
            this.Row = row;
            this.Col = col;
            this.Value = spotValue;
        }
    }

    public enum SpotValue
    {
        Empty,
        White,
        Black
    }
}
