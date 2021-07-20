using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class SearchRequestModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Classification Classification => 0;
        public string Type => "all";
        public int Age;
        public string Name;
        public DateTime DateAcquired;
        public bool Ascending => true;
   }
}