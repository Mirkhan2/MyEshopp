using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEshopp.Models
{
    public class Catagory
    {
        //[Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CatagoryToProduct> CatagoryToProducts { get; set; }


    }
}
