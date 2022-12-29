using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ProductsFilterDomain
    {
        public string Term { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
