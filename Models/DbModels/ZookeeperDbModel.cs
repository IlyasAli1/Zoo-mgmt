using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo.Models.DbModels
{
    public class ZookeeperDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimalDbModel> Animals { get; set; }
        public List<EnclosureDbModel> Enclosures { get; set; }
    }
}
