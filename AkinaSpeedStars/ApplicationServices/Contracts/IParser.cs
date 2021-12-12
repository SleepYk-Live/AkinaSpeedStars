using AkinaSpeedStars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices.Contracts
{
    internal interface IParser
    {
        public string ModelsUrl { get; set; }
        public Task<IEnumerable<Car>> GetModels();
        public Task<IEnumerable<Kit>> GetKits(string model);
        public Task<IEnumerable<PartGroup>> GetPartGroups(string model, string kit);
        public Task<IEnumerable<PartSubgroup>> GetPartSubgroups(string model, string kit, string group);
        public Task<Scheme> GetScheme(string model, string kit, string group, string partName);
    }
}
