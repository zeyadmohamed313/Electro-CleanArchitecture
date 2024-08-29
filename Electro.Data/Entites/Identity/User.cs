using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Electro.Data.Entites.Identity
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
   
        public int? CartId {  get; set; }
        public Cart Cart { get; set; }
        public int? FavouriteListId {  get; set; }
        public FavouriteList FavouriteList {  get; set; }
        public List<Order> OrderList { get; set; }
        public List<Payments>  PaymentsList { get; set; }
        public List<Review> ReviewsList {  get; set; }


    }
}
