using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Interface Iwriteable demands the class implemeting it being able to write data.
    /// </summary>
    public interface Iwriteable
    {
        /// <summary>
        ///  Write function signature.
        /// </summary>
        public void Write(string data);
        /// <summary>
        ///  WriteEnterGridMessage function signature.
        /// </summary>
        public void WriteEnterGridMessage(Reader reader);
    }
}
