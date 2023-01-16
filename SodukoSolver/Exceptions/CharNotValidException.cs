using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Exceptions
{
    /// <summary>
    /// Class CharNotValidException represents the CharNotValid exception.
    /// This exception informs the user that one char that he inserted the grid is not valid.
    /// </summary>
    public class CharNotValidException : Exception
    {
        public CharNotValidException(string message) : base(message)
        {
            /// <summary>
            /// This constructor is in charge of creating a CharNotValidException object.
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
