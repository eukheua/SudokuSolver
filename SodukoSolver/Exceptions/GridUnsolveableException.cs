using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Exceptions
{
    /// <summary>
    /// Class GridUnsolveableException represents the GridUnsolveable exception.
    /// This exception informs the user that the grid inserted is unsolvable.
    /// </summary>
    public class GridUnsolveableException : Exception
    {
        public GridUnsolveableException(string message) : base(message)
        {
            /// <summary>
            /// This constructor is in charge of creating a GridUnsolveableException object.
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
