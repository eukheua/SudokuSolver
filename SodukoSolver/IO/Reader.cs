using SodukoSolver.Exceptions;
using SodukoSolver.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class Reader is in charge of reading sudoku grids related information.
    /// </summary>
    class Reader : Ireadable
    {
        /// <attributes>
        /// reader - a generic reader object (could be FileReader or ConsoleReader).
        /// </attributes>
        private readonly Ireadable reader;
        public Reader(Ireadable reader)
        {
            /// <summary>
            /// This constructor creates a Reader object.
            /// </summary>
            /// <param>
            /// reader - generic reader object.
            /// </param>
            /// <returns>
            ///  Nothing.
            /// </returns>
            this.reader = reader;
        }
        public string Read()
        {
            /// <summary>
            /// This function reads input from user according to the input format he chose.
            /// in case of exceptions in reading it throws them to main.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// The data.
            /// </returns>
            string board = reader.Read();
            if (board == "exit")
            {
                return board;
            }
            if (!Validator.AreDimensionsValid(board))
            {
                string message = string.Format("String size {0} doesnt represent supported board dimensions ", board.Length);
                message += Config.SupportedDimensionsString;
                throw new DimensionsOfBoardNotValidException(message);
            }
            char potentialValidChar = Validator.AreAllCharsValid(board);
            if (potentialValidChar != ' ')
            {
                string message = string.Format("Character '{0}' is not valid in this soduko grid", potentialValidChar);
                message += string.Format("\nIn this grid the valid characters are from '0' to '{0}'", (char)(Math.Sqrt(board.Length) + '0'));
                throw new CharNotValidException(message);
            }
            string potentialMessage = Validator.IsGridValid(board);
            if (Validator.IsGridValid(board) != "")
            {
                string message = potentialMessage;
                throw new GridNotValidException(message);
            }

            return board;
        }
        public Ireadable getReader()
        {
            /// <summary>
            /// This function returns the reader attribute.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// The reader attribute.
            /// </returns>
            return reader;
        }
    }
}
