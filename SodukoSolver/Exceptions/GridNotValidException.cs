using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Exceptions
{
    /// <summary>
    /// Class GridNotValidException represents the GridNotValid exception.
    /// This exception informs the user that an invalid grid was entered.
    /// </summary>
    public class GridNotValidException : Exception
    {
        /// <summary>
        /// This constructor is in charge of creating a GridNotValidException object.
        /// </summary>
        /// <param>
        /// message - message of exception.
        /// </param>
        /// <returns>
        /// Nothing.
        /// </returns>
        public GridNotValidException(string message) : base(message)
        { 

        }
    }
}
