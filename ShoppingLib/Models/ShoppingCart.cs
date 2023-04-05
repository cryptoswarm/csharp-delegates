namespace ShoppingLib.Models
{
    public class ShoppingCart
    {
        private IEnumerable<Product> Items = new List<Product>();

        public delegate void GetDiscount(decimal subtotal);

        public decimal GetCartTotal(GetDiscount getSubTotal, 
                                    Func<IEnumerable<Product>, decimal, decimal> getDiscountedTotal, // list of product, subtotal and finally result
                                    Action<string> notifyCustomer) 
        {
            decimal subTotal = Items.Sum(_ => _.Price);

            getSubTotal(subTotal);

            notifyCustomer("Applying your discount."); // simulate logging

            return getDiscountedTotal(Items, subTotal);
        }

        public void AddItems(Product product)
        {
            Items = Items.Append(product);
        }
    }
}