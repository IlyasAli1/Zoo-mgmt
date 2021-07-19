﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo.Models.DbModels
{
    
    public class AnimalDbEnums
    {
        public enum Classification
        {
            Mammal,
            Reptile,
            Bird,
            Insect,
            Fish,
            Invertebrate

        }
        public enum Sex
        { 
            Male,
            Female
        }
    }
}
