using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Exceptions
{
    /// <summary>
    /// Class DimensionsOfBoardNotValidException represents the DimensionsOfBoardNotValid exception.
    /// This exception informs the user that one char that the dimensions of the grid he inserted are not valid.
    /// </summary>
    internal class DimensionsOfBoardNotValidException : Exception
    {
        public DimensionsOfBoardNotValidException(string message) : base(message)
        {
            /// <summary>
            /// This constructor is in charge of creating a DimensionsOfBoardNotValidException object.
            /// </summary>
            /// <param>
            /// message - message of exception.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>

        }
    }
}
