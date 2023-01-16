using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Interface Ireadable demands the class implemeting it being able to read data.
    /// </summary>
    public interface Ireadable
    {
        /// <summary>
        ///  Read function signature.
        /// </summary>
        public string Read();
    }
}
