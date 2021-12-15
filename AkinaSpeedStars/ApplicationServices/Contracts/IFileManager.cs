using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices.Contracts
{
    /// <summary>
    /// This interface created for future unit testing purposes
    /// It is easier to test future classes which would use IFileManager reference
    /// </summary>
    internal interface IFileManager
    {
        public string GetImage(string url);
    }
}
