using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class FavouriteList
    {
        public int Id { get; set; }  // Unique identifier for the favorite list
        public int UserId { get; set; }  // Identifier of the user who owns the favorite list
        public DateTime CreatedDate { get; set; }  // Date when the favorite list was created
        public DateTime? LastUpdated { get; set; }  // Date when the favorite list was last updated

        // Navigation properties
        public virtual User User { get; set; }  // The user who owns the favorite list
        public virtual ICollection<FavouriteItem> FavoriteItems { get; set; }  // List of items in the favorite list

        public FavouriteList()
        {
            FavoriteItems = new List<FavouriteItem>();
        }
    }
}
