namespace Task2_InventoryManagement
{
    public class ProductManager
    {
        private readonly List<Product> _sortedProducts;

        public ProductManager()
        {
            var newProducts = new List<Product>()
            {
                new Product(name: "Product A", price: 100, stock: 5),
                new Product(name: "Product B", price: 200, stock: 3),
                new Product(name: "Product C", price: 50, stock: 10)
            };

            var sortKey = "price";
            var ascending = false;

            _sortedProducts = GetSortedProducts(newProducts, sortKey, ascending);
        }

        public List<Product> GetSortedProducts(List<Product> currentProducts, string sortKey, bool ascending)
        {
            // Check valid sort key
            List<string> validKeys = new() { "name", "price", "stock" };

            if (!validKeys.Contains(sortKey))
                throw new ArgumentException("Invalid sort key. Must be 'name', 'price', or 'stock'.");

            // Check Sort Key and Sort accordingly
            return sortKey switch
            {
                "name" => ascending
                        ? currentProducts.OrderBy(x => x.Name).ToList()
                        : currentProducts.OrderByDescending(x => x.Name).ToList(),
                "price" => ascending
                        ? currentProducts.OrderBy(x => x.Price).ToList()
                        : currentProducts.OrderByDescending(x => x.Price).ToList(),
                "stock" => ascending
                        ? currentProducts.OrderBy(x => x.Stock).ToList()
                        : currentProducts.OrderByDescending(x => x.Stock).ToList(),

                _ => throw new InvalidOperationException("Unable to Sort Products!"),
            };
        }
    }
}