using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class SearchRequestModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Classification? Classification { get; set; }
        public string Type{ get; set; } = "all";
        public int Age { get; set; } = 0;
        public string Name { get; set; } = null;
        public DateTime DateAcquired { get; set; } = default(DateTime);
        public bool Ascending { get; set; } = true;
   }
}