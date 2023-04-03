namespace ShoppingLib.Models
{
    public class ShoppingCart
    {
        private IEnumerable<Product> Items = new List<Product>();

        public decimal GetCartTotal()
        {
            decimal subTotal = Items.Sum(_ => _.Price);

            switch (subTotal)
            {
                case > 100:
                    return subTotal * 0.80M;
                case > 50:
                    return subTotal * 0.85M;
                case > 10:
                    return subTotal * 0.90M;
                default:
                    return subTotal;
            }
        }

        public void AddItems(Product product)
        {
            Items = Items.Append(product);
        }
    }
}