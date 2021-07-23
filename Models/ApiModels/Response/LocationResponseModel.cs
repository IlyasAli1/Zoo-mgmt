using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class LocationResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<TransferResponseModel> Transfers { get; set; }

        public LocationResponseModel(LocationDbModel location, bool loadDependencies = false)
        {
            Id = location.Id;
            Name = location.Name;
            if (!string.IsNullOrEmpty(location.Address))
            {
                Address = location.Address;
            }

            if (loadDependencies)
            {
                Transfers = location.Transfers.Select(t => new TransferResponseModel(t)).ToList();
            }
        }
    }
}
