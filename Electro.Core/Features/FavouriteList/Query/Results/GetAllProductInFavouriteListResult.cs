using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Query.Results
{
    public class GetAllProductInFavouriteListResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL {  get; set; }
        public decimal FinalPrice { get; set; }
    }
}
