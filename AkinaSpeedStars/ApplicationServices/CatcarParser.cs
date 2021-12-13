using AkinaSpeedStars.ApplicationServices.Contracts;
using AkinaSpeedStars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices
{
    /// <summary>
    /// Catcar parser implementation
    /// </summary>
    // TODO: implement parsing for Catcar
    internal class CatcarParser : IParser
    {
        public string ModelsUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<IEnumerable<Kit>> GetKits(string model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetModels()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PartGroup>> GetPartGroups(string model, string kit)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PartSubgroup>> GetPartSubgroups(string model, string kit, string group)
        {
            throw new NotImplementedException();
        }

        public Task<Scheme> GetScheme(string model, string kit, string group, string partName)
        {
            throw new NotImplementedException();
        }
    }
}
