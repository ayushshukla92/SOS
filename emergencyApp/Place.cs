using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace emergencyApp
{
        [DataContract]
        public class Place
        {/*
            [DataMember(Name = "summary")]
            public string Summary { get; set; }

            [DataMember(Name = "distance")]
            public string Distance { get; set; }

            [DataMember(Name = "rank")]
            public string Rank { get; set; }
            */
            [DataMember(Name = "title")]
            public string Title { get; set; }

            [DataMember(Name = "distance")]
            public string Distance { get; set; }

            [DataMember(Name = "position")]
            public string position { get; set; }

            [DataMember(Name = "icon")]
            public string iconLink { get; set; }
            
            /*
            [DataMember(Name = "wikipediaUrl")]
            public string WikipediaUrl { get; set; }

            [DataMember(Name = "elevation")]
            public string Elevation { get; set; }

            [DataMember(Name = "lng")]
            public string Longitude { get; set; }

            [DataMember(Name = "feature")]
            public string Feature { get; set; }

            [DataMember(Name = "lang")]
            public string Langauge { get; set; }
            
            [DataMember(Name = "lat")]
            public string Latitude { get; set; }
          
          

            [DataMember(Name = "title")]
            public string Title { get; set; }*/
       }
    
}
