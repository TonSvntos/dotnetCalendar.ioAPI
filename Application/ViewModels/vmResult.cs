using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Application.ViewModels
{
    public class vmResult
    {
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string FriendlyErrorMessage { get; set; }
        [DataMember]
        public string StackTrace { get; set; }

    }
}
