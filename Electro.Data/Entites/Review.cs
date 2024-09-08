using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating {  get; set; }
        public string ReviewText {  get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
