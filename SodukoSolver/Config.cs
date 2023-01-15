using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    /// <summary>
    /// Class Config is in charge of saving constants for printing or general information.
    /// </summary>
    internal static class Config
    {
        public static int[] SupportedDimensions = { 1, 4, 9, 16, 25 };
        public static string SupportedDimensionsString = "1,4,9,16,25";





        public static string StringTop1On1 = "╔+╗\n║";
        public static string StringMiddleOne1On1 = "\n╟-╫-╢\n║";
        public static string StringMiddleTwo1On1 = "\n╠+╬+╣\n║";
        public static string StringBottom1On1 = "\n╚+╝";

        public static string StringTop4On4 = "╔+╤+╦+╤+╗\n║";
        public static string StringMiddleOne4On4 = "\n╟-┼-╫-┼-╢\n║";
        public static string StringMiddleTwo4On4 = "\n╠+╪+╬+╪+╣\n║";
        public static string StringBottom4On4 = "\n╚+╧+╩+╧+╝";

        public static string StringTop9On9 = "╔+╤+╤+╦+╤+╤+╦+╤+╤+╗\n║";
        public static string StringMiddleOne9On9 = "\n╟-┼-┼-╫-┼-┼-╫-┼-┼-╢\n║";
        public static string StringMiddleTwo9On9 = "\n╠+╪+╪+╬+╪+╪+╬+╪+╪+╣\n║";
        public static string StringBottom9On9 = "\n╚+╧+╧+╩+╧+╧+╩+╧+╧+╝";

        public static string StringTop16On16 = "╔+╤+╤+╤+╦+╤+╤+╤+╦+╤+╤+╤+╦+╤+╤+╤+╗\n║";
        public static string StringMiddle16On16 = "\n╟-┼-┼-┼-╫-┼-┼-┼-╫-┼-┼-┼-╫-┼-┼-┼-╢\n║";
        public static string StringMiddleTwo16On16 = "\n╠+╪+╪+╪+╬+╪+╪+╪+╬+╪+╪+╪+╬+╪+╪+╪+╣\n║";
        public static string StringBottom16O16 = "\n╚+╧+╧+╧+╩+╧+╧+╧+╩+╧+╧+╧+╩+╧+╧+╧+╝";

        public static string StringTop25On25 = "╔+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╗\n║";
        public static string StringMiddle25On25 = "\n╟-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╢\n╣";
        public static string StringMiddleTwo25On25 = "\n╠+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╣\n║";
        public static string StringBottom25On25 = "\n╚+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╝";

        public static string ReplaceEqualSign = "═══";
        public static string ReplaceHyphenSign = "───";
    }
}
