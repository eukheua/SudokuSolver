using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal static class Config
    {
        public static string stringTop1On1 = "╔+╗\n║";
        public static string stringMiddleOne1On1 = "\n╟-╫-╢\n║";
        public static string stringMiddleTwo1On1 = "\n╠+╬+╣\n║";
        public static string stringBottom1On1 = "\n╚+╝";

        public static string stringTop4On4 = "╔+╤+╦+╤+╗\n║";
        public static string stringMiddleOne4On4 = "\n╟-┼-╫-┼-╢\n║";
        public static string stringMiddleTwo4On4 = "\n╠+╪+╬+╪+╣\n║";
        public static string stringBottom4On4 = "\n╚+╧+╩+╧+╝";

        public static string stringTop9On9 = "╔+╤+╤+╦+╤+╤+╦+╤+╤+╗\n║";
        public static string stringMiddleOne9On9 = "\n╟-┼-┼-╫-┼-┼-╫-┼-┼-╢\n║";
        public static string stringMiddleTwo9On9 = "\n╠+╪+╪+╬+╪+╪+╬+╪+╪+╣\n║";
        public static string stringBottom9On9 = "\n╚+╧+╧+╩+╧+╧+╩+╧+╧+╝";

        public static string stringTop16On16 = "╔+╤+╤+╤+╦+╤+╤+╤+╦+╤+╤+╤+╦+╤+╤+╤+╗\n║";
        public static string stringMiddle16On16 = "\n╟-┼-┼-┼-╫-┼-┼-┼-╫-┼-┼-┼-╫-┼-┼-┼-╢\n║";
        public static string stringMiddleTwo16On16 = "\n╠+╪+╪+╪+╬+╪+╪+╪+╬+╪+╪+╪+╬+╪+╪+╪+╣\n║";
        public static string stringBottom16O16 = "\n╚+╧+╧+╧+╩+╧+╧+╧+╩+╧+╧+╧+╩+╧+╧+╧+╝";

        public static string stringTop25On25 = "╔+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╦+╤+╤+╤+╤+╗\n║";
        public static string stringMiddle25On25 = "\n╟-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╫-┼-┼-┼-┼-╢\n╣";
        public static string stringMiddleTwo25On25 = "\n╠+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╬+╪+╪+╪+╪+╣\n║";
        public static string stringBottom25On25 = "\n╚+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╩+╧+╧+╧+╧+╝";

        public static string replaceEqualSign = "═══";
        public static string replaceHyphenSign = "───";
    }
}
