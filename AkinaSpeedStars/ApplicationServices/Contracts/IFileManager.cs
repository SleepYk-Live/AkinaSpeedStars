using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices.Contracts
{
    internal interface IFileManager
    {
        public string GetImage(string url);
    }
}
