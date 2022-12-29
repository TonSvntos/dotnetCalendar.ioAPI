
using System.Runtime.Serialization;


namespace Application.ViewModels
{
    public class vmProductsFilter
    {
        [DataMember]
        public string Term { get; set; }
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int PageSize { get; set; }
    }
}
