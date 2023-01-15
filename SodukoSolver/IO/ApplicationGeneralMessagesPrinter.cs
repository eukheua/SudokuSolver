using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class ApplicationGeneralMessagesPrinter is in charge of displaying general messages to user.
    /// </summary>
    internal static class ApplicationGeneralMessagesPrinter
    {
        public static void PrintOpeningMessage()
        {
            /// <summary>
            /// This function displays the opening screen message.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine(@"   ,-,--.                             _,.---._    ,--.-.,-.                  
 ,-.'-  _\ .--.-. .-.-. _,..---._   ,-.' , -  `. /==/- |\  \ .--.-. .-.-.    
/==/_ ,_.'/==/ -|/=/  /==/,   -  \ /==/_,  ,  - \|==|_ `/_ //==/ -|/=/  |    
\==\  \   |==| ,||=| -|==|   _   _\==|   .=.     |==| ,   / |==| ,||=| -|    
 \==\ -\  |==|- | =/  |==|  .=.   |==|_ : ;=:  - |==|-  .|  |==|- | =/  |    
 _\==\ ,\ |==|,  \/ - |==|,|   | -|==| , '='     |==| _ , \ |==|,  \/ - |    
/==/\/ _ ||==|-   ,   /==|  '='   /\==\ -    ,_ //==/  '\  ||==|-   ,   /    
\==\ - , //==/ , _  .'|==|-,   _`/  '.='. -   .' \==\ /\=\.'/==/ , _  .'     
 `--`---' `--`..---'  `-.`.____.'     `--`--''    `--`      `--`..---'       
          ,-,--.    _,.---._                   ,-.-.    ,----.               
        ,-.'-  _\ ,-.' , -  `.    _.-.  ,--.-./=/ ,/ ,-.--` , \  .-.,.---.   
       /==/_ ,_.'/==/_,  ,  - \ .-,.'| /==/, ||=| -||==|-  _.-` /==/  `   \  
       \==\  \  |==|   .=.     |==|, | \==\,  \ / ,||==|   `.-.|==|-, .=., | 
        \==\ -\ |==|_ : ;=:  - |==|- |  \==\ - ' - /==/_ ,    /|==|   '='  / 
        _\==\ ,\|==| , '='     |==|, |   \==\ ,   ||==|    .-' |==|- ,   .'  
       /==/\/ _ |\==\ -    ,_ /|==|- `-._|==| -  ,/|==|_  ,`-._|==|_  . ,'.  
       \==\ - , / '.='. -   .' /==/ - , ,|==\  _ / /==/ ,     //==/  /\ ,  ) 
        `--`---'    `--`--''   `--`-----' `--`--'  `--`-----`` `--`-`--`--'  ");
            Console.WriteLine("Hello user and welcome to my sudoku solver!!!");
            Console.WriteLine("The solver supports these dimensions for the grids: 1,4,9,16,25");
            Console.WriteLine("Sudoku grids are received as strings the length of the amount of cells in the grid");
            Console.WriteLine("You can choose either the console or a file to enter the grid and recieve it back solved");

        }
        public static void PrintGoodByeMessage()
        {
            /// <summary>
            /// This function displays the goodbye message.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine(@"
      _,---.     _,.---._       _,.---._                 
  _.='.'-,  \  ,-.' , -  `.   ,-.' , -  `.   _,..---._   
 /==.'-     / /==/_,  ,  - \ /==/_,  ,  - \/==/,   -  \  
/==/ -   .-' |==|   .=.     |==|   .=.     |==|   _   _\ 
|==|_   /_,-.|==|_ : ;=:  - |==|_ : ;=:  - |==|  .=.   | 
|==|  , \_.' )==| , '='     |==| , '='     |==|,|   | -| 
\==\-  ,    ( \==\ -    ,_ / \==\ -    ,_ /|==|  '='   / 
 /==/ _  ,  /  '.='. -   .'   '.='. -   .' |==|-,   _`/  
 `--`------'     `--`--''       `--`--''   `-.`.____.'   
                                     ,----.              
           _..---.  ,--.-.  .-,--.,-.--` , \             
         .' .'.-. \/==/- / /=/_ /|==|-  _.-`             
        /==/- '=' /\==\, \/=/. / |==|   `.-.             
        |==|-,   '  \==\  \/ -/ /==/_ ,    /             
        |==|  .=. \  |==|  ,_/  |==|    .-'              
        /==/- '=' ,| \==\-, /   |==|_  ,`-._             
       |==|   -   /  /==/._/    /==/ ,     /             
       `-._`.___,'   `--`-`     `--`-----``              
");
        }
    }
}
