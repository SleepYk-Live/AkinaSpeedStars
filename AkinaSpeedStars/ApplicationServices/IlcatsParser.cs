using AkinaSpeedStars.ApplicationServices.Contracts;
using AkinaSpeedStars.Models;
using AngleSharp;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices
{
    /// <summary>
    /// 
    /// </summary>
    // TODO: Provide multithreading processing for all methods
    internal class IlcatsParser : IParser
    {
        private readonly IConfiguration _configuration;
        public string ModelsUrl { get; set; }

        public List<string> PartGroupsUrls { get { return null; } }

        public IlcatsParser()
        {
            ModelsUrl = "https://www.ilcats.ru/toyota/?function=getModels&market=EU";
            _configuration = Configuration.Default.WithDefaultLoader();
        }

        public async Task<IEnumerable<Kit>> GetKits(string model)
        {
            var models = await GetModels();
            var urls = models.Where(x => x.ModelName == model).FirstOrDefault().ModelLinks;
            var kits = new List<Kit>();

            foreach(var url in urls)
            {
                var document = await BrowsingContext.New(_configuration).OpenAsync(url);
                var table = document.GetElementsByTagName("tbody").FirstOrDefault();
                var rows = table.GetElementsByTagName("tr").Skip(1);

                foreach (var row in rows)
                {
                    Kit kit = new Kit();
                    var cells = row.GetElementsByTagName("td").Skip(2);
                    var navigation = row.GetElementsByTagName("td").Take(1).Single().GetElementsByTagName("a").FirstOrDefault();
                    kit.Name = navigation.TextContent;
                    kit.Link = (navigation as IHtmlAnchorElement).Href;

                    kit.Engine = cells.ElementAtOrDefault(0) == null ? "Empty" : cells.ElementAt(0).TextContent;
                    kit.Body = cells.ElementAtOrDefault(1) == null ? "Empty" : cells.ElementAt(1).TextContent;
                    kit.Grade = cells.ElementAtOrDefault(2) == null ? "Empty" : cells.ElementAt(2).TextContent;
                    kit.Transmission = cells.ElementAtOrDefault(3) == null ? "Empty" : cells.ElementAt(3).TextContent;
                    kit.GearShiftType = cells.ElementAtOrDefault(4) == null ? "Empty" : cells.ElementAt(4).TextContent;
                    kit.DriverPosition = cells.ElementAtOrDefault(5) == null ? "Empty" : cells.ElementAt(5).TextContent;
                    kit.NumberOfDoors = cells.ElementAtOrDefault(6) == null ? "Empty" : cells.ElementAt(6).TextContent;
                    kit.Destination = cells.ElementAtOrDefault(7) == null ? "Empty" : cells.ElementAt(7).TextContent;
                    kit.AdditionalDestination = cells.ElementAtOrDefault(8) == null ? "Empty" : cells.ElementAt(8).TextContent;

                    kits.Add(kit);
                }

            }

            return kits;
        }

        public async Task<IEnumerable<Car>> GetModels()
        {
            var document = await BrowsingContext.New(_configuration).OpenAsync(ModelsUrl);
            var carName = document.GetElementById("MainMenu").GetElementsByTagName("li")[1].TextContent.Split(':').LastOrDefault();
            var catalog = document.GetElementsByClassName("List Multilist").FirstOrDefault().Children;

            List<Car> cars = new List<Car>();

            foreach (var catalogItem in catalog)
            {
                Car car = new Car();
                car.Name = carName;
                car.ModelName = catalogItem.GetElementsByClassName("name").FirstOrDefault().TextContent;

                foreach (var it in catalogItem.GetElementsByTagName("a"))
                {
                    //--ModelCode
                    car.ModelCodes.Add(it.TextContent);
                    //--ModelLink
                    car.ModelLinks.Add((it as IHtmlAnchorElement).Href);
                }

                foreach (var it in catalogItem.GetElementsByClassName("dateRange"))
                {
                    //--Start/End
                    car.Start.Add(it.TextContent.Split('-').First());
                    car.End.Add(it.TextContent.Split('-').Last());
                }

                //--Kit
                foreach (var it in catalogItem.GetElementsByClassName("modelCode"))
                {
                    car.Kits.AddRange(it.TextContent.Split(','));
                }

                cars.Add(car);
            }

            return cars;
        }

        public async Task<IEnumerable<PartGroup>> GetPartGroups(string model, string kit)
        {
            var partGroups = new List<PartGroup>();
            var kits = await GetKits(model);
            var url = kits.Where(x => x.Name == kit).Select(x => x.Link).FirstOrDefault();
            var document = await BrowsingContext.New(_configuration).OpenAsync(url);
            var categories = document.GetElementsByClassName("name");

            foreach(var category in categories)
            {
                PartGroup partGroup = new PartGroup();
                partGroup.Name = category.TextContent;
                partGroup.Link = (category.GetElementsByTagName("a").Single() as IHtmlAnchorElement).Href;
                partGroups.Add(partGroup);
            }

            return partGroups;
        }

        public async Task<IEnumerable<PartSubgroup>> GetPartSubgroups(string model, string kit, string group)
        {
            var partSubgroups = new List<PartSubgroup>();
            var partGroups = await GetPartGroups(model, kit);
            var url = partGroups.Where(x => x.Name == group).Select(x => x.Link).Single();
            var document = await BrowsingContext.New(_configuration).OpenAsync(url);
            var subGroups = document.GetElementsByClassName("name");

            foreach(var subgroupItem in subGroups)
            {
                var subgroup = new PartSubgroup();
                subgroup.Name = subgroupItem.TextContent;
                subgroup.Link = (subgroupItem.GetElementsByTagName("a").FirstOrDefault() as IHtmlAnchorElement).Href;
                partSubgroups.Add(subgroup);
            }

            return partSubgroups;
        }

        public async Task<Scheme> GetScheme(string model, string kit, string group, string partName)
        {
            var scheme = new Scheme();
            var subgroups = await GetPartSubgroups(model, kit, group);
            var url = subgroups.Where(x => x.Name == partName).Select(x => x.Link).First();
            var document = await BrowsingContext.New(_configuration).OpenAsync(url);
            scheme.ImageUrl = document.Images.First().Source;
            scheme.Name = partName;

            List<PartTree> parts = new List<PartTree>();
            var table = document.GetElementsByTagName("tbody").First();
            var partTrees = table.GetElementsByTagName("tr").Where(x => x.ChildElementCount == 1);
            var nodes = table.GetElementsByTagName("tr").Except(partTrees);

            foreach (var partTreeItem in partTrees)
            {
                var partTree = new PartTree();
                partTree.Name = partTreeItem.GetElementsByTagName("th").First().TextContent.Skip(5).ToString();
                partTree.Code = partTreeItem.GetElementsByTagName("th").First().TextContent.Take(5).ToString();
                partTree.Parts = new List<Part>();

                foreach (var node in nodes.Where(x => x.ClassName == partTreeItem.ClassName))
                {
                    var columns = node.GetElementsByTagName("td");

                    Part part = new Part();
                    part.Code = columns.ElementAt(0).TextContent;
                    part.Count = columns.ElementAt(1).TextContent;
                    part.ProductionRange = columns.ElementAt(2).TextContent;
                    part.Info = columns.ElementAt(3).TextContent;

                    partTree.Parts.Add(part);
                }
                parts.Add(partTree);
            }
            scheme.PartTrees = parts;

            return scheme;
        }
    }
}
