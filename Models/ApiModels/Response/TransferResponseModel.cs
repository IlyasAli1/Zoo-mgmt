using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class TransferResponseModel
    {
        public int Id { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public bool Inbound { get; set; }
        public AnimalResponseModel Animal { get; set; }
        public LocationResponseModel Location { get; set; }

        public TransferResponseModel(TransferDbModel transfer, bool loadDependencies = false)
        {
            Id = transfer.Id;
            DateOfTransfer = transfer.DateOfTransfer;
            Inbound = transfer.Inbound;
            Location = new LocationResponseModel(transfer.Location);

            if (loadDependencies)
            {
                Animal = new AnimalResponseModel(transfer.Animal);
            }
        }
    }
}
