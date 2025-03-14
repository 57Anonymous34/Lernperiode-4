using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpielParadies
{
    internal class Settings
    {
        public static int Width { get; set; } 
        public static int Height { get; set; } 

        public static string directions { get; set; }
        public Settings()
        {
            Width = 27;
            Height = 27;
            directions = "left";
        }
    }
}
