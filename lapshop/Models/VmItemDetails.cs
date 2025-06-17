using System.ComponentModel.DataAnnotations.Schema;

namespace lapshop.Models
{
    [NotMapped]
    public class VmItemDetails
    {

        public VmItemDetails() {

            RelatedItems = new List<VwItem>();
            Items = new VwItem();
        
        }

        public int VmId { get; set; } 

      public  List<VwItem> RelatedItems { get; set; }
       public VwItem Items { get; set; }

    }
}
