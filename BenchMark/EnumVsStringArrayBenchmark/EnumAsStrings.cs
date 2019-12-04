using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BenchMarkApp.EnumVsStringArray
{
    public enum EnumColors
    {
        [Description("Red")]
        Red,

        [Description("Orange Sherbert")]
        Orange,

        [Description("Teal Blue")]
        Blue,

        [Description("Green")]
        Green,

        [Description("Violet")]
        Purple,

        [Description("Black")]
        Black
    }


    public static class EnumAsStrings
    {
        public const string RED = "Red";
        public const string ORANGE = "Orange Sherbert";
        public const string BLUE = "Teal Blue";
        public const string GREEN = "Green";
        public const string PURPLE = "Violet";
        public const string BLACK = "Black";

        public static readonly string[] Values = {RED, ORANGE, BLUE, GREEN, PURPLE, BLACK};
    }


}
