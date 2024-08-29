using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class FavouriteItem
    {
        public int Id { get; set; }  // Unique identifier for the favorite item
        public int FavoriteListId { get; set; }  // Identifier of the favorite list
        public int ProductId { get; set; }  // IdentifAcier of the product
        public string ProductName { get; set; }  // Name of the product
        public DateTime AddedDate { get; set; }  // Date when the product was added to the favorite list

        // Navigation properties
        public virtual FavouriteList FavoriteList { get; set; }  // The favorite list to which this item belongs
        public virtual Product Product { get; set; }  // The product that was added to the favorite list
    }
}
