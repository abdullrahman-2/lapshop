namespace lapshop.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(){

            CartItems = new List<ShoppingCart>();
        }
        
        public decimal total { get; set; }
        public List<ShoppingCart> CartItems { get; set; }
    }
}
