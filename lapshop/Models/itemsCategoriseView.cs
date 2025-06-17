namespace lapshop.Models
{
    public class itemsCategoriseView
    {
        public string CategoryName { get; set; } = null!;

        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;

        public decimal SalesPrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public int CategoryId { get; set; }
    }
}
