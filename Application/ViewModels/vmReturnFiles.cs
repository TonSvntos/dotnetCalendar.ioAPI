using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class vwReturnFiles
    {
        [DataMember]
        public string dsError { get; set; }
        [DataMember]
        public string nmFile { get; set; }
        [DataMember]
        public string dsExceptionError { get; set; }
        [DataMember]
        public string content { get; set; }
    }
}
