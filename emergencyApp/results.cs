using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace emergencyApp
{
    [DataContract]
    public class results
    {
        [DataMember(Name = "results")]
        public PlacesList response { get; set; }
    }
    
}
