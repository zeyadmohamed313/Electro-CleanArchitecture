using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
        public bool TopSelling { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string Brand { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public string ShippingWeight { get; set; }
        public decimal ShippingCost { get; set; }
        public int Rating { get; set; }
        public List<Review> ReviewsList { get; set; }
        public int NumberOfStarts {  get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public List<CartItem> CartItemsList {  get; set; }
        public List<FavouriteItem> FavouriteItemsList { get; set; }
        public List<OrderItem> OrderItemsList {  get; set; }

        // Best Practise To Ensure Null Referance 
        public Product()
        {
            CartItemsList = new List<CartItem> { };
            FavouriteItemsList = new List<FavouriteItem> { };
            OrderItemsList = new List<OrderItem> { };
        }
    }
}
