﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace emergencyApp
{
    [DataContract]
    public class PlacesList
    {
        [DataMember(Name = "items")]
        public List<Place> PlaceList { get; set; }
    }





}
