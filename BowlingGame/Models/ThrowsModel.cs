using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingGame.Models
{
    public class ThrowsModel
    {
        public int throwNumber { get; set; }

        public int frameNumber { get; set; }

        public int score { get; set; }

        public ThrowsModel(int tn, int fn, int sc)
        {
            throwNumber = tn;
            frameNumber = fn;
            sc = score;
        }
    }
}