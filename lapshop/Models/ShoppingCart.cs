namespace lapshop.Models
{
    public class ShoppingCart
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
         public int Qty { get; set; }

      public  decimal totalPice { get; set; }
        public decimal Price { get; set; }

    }
}
