using AkinaSpeedStars.BL.Application.Contracts;
using AkinaSpeedStars.BL.Infrastructure;
using AkinaSpeedStars.BL.Infrastructure.Contracts;
using AkinaSpeedStars.BL.Models.Converters;
using AkinaSpeedStars.DAL.Data;
using AkinaSpeedStars.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.BL.Application
{
    /// <summary>
    /// It is main processing class
    /// It gets all models related data and insert
    /// </summary>
    /// TODO: test this class
    internal class ContentHandler
    {
        private readonly IUnitOfWork _db;
        private IParser _parser;
        private readonly string _url;

        public ContentHandler(IUnitOfWork db, IParser parser, string url)
        {
            // provide error handling instead 
            _db = db ?? new UnitOfWork(null);
            _url = url;
            _parser = parser;
        }

        public async void Process()
        {
            _parser.ModelsUrl = _url;
            AddModels();
            AddKits();
            AddGroups();
            AddSubgroupsAndSchemes();
        }

        // TODO: fix if it adds duplicates
        private async void AddModels()
        {
            var result = await _parser.GetModels();

            foreach (var it in result)
            {
                var car = CarConverter.ToSource(it);
                _db.Cars.Create(car);

                foreach (var code in it.ModelCodes)
                {
                    _db.ModelCodes.Create(ModelCodeConverter.ToSource(car, code));
                }
            }
        }

        private async void AddKits()
        {
            var modelCodes = _db.ModelCodes.GetAll();

            foreach (var code in modelCodes)
            {
                var result = await _parser.GetKits(code.Code);
                foreach (var it in result)
                {
                    _db.Kits.Create(KitConverter.ToSource(it, code));
                }
            }
        }

        private async void AddGroups()
        {
            var kits = _db.Kits.GetAll();

            foreach (var kit in kits)
            {
                var result = await _parser.GetPartGroups(kit.ModelCode.Code, kit.Name);
                foreach (var it in result)
                {
                    _db.PartGroups.Create(PartGroupConverter.ToSource(it));
                }
            }
        }

        // TODO: Simplify this method, too much nested loops
        private async void AddSubgroupsAndSchemes()
        {
            var groups = _db.PartGroups.GetAll();

            foreach (var group in groups)
            {
                var kits = group.Kits;
                foreach (var kit in kits)
                {
                    var result = await _parser.GetPartSubgroups(kit.ModelCode.Car.ModelName, kit.Name, group.Name);
                    foreach (var it in result)
                    {
                        var scheme = await _parser.GetScheme(kit.ModelCode.Car.ModelName, kit.Name, group.Name, it.Name);
                        // TODO: provide file path
                        var partSubgroup = PartSubgroupConverter.ToSource(it, group, SchemeConverter.ToSource(scheme, null, new FileManager("/")));
                        _db.PartSubgroups.Create(partSubgroup);
                        var sc = _db.Scheme.Find(s => s.Image == scheme.ImageUrl).Single();

                        foreach (var item in scheme.PartTrees)
                        {
                            var partTree = PartTreeConverter.ToSource(item, sc);
                            _db.PartTrees.Create(partTree);
                            foreach (var part in item.Parts)
                            {
                                _db.Parts.Create(PartConverter.ToSource(part, partTree));
                                _db.PartTrees.Update(partTree);
                            }
                        }

                        sc.PartSubgroup = partSubgroup;
                        _db.Scheme.Update(sc);
                    }
                }
            }
        }
    }
}
