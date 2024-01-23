namespace Task2_InventoryManagement
{
    public class Product
    {
        private string _name;
        private float _price;
        private int _stock;

        public string Name 
        {  
            get => _name; 
            set {  if (_name != value) _name = value; }
        }
        public float Price
        {
            get => _price;
            set { if (_price != value) _price = value; }
        }

        public int Stock
        {
            get => _stock;
            set { if (_stock != value) _stock = value; }
        }

        public Product(string name, float price, int stock)
        {
            _name = name;
            _price = price;
            _stock = stock;
        }
    }
}
