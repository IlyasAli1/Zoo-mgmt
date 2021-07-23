using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.Enums;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class ZookeeperRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<int> EnclosureIds { get; set; }
    }
}
