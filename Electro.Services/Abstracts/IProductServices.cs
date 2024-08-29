using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IProductServices
    {
        Task<string> AddProduct(Product category);
        Task<string> UpdateProduct(Product category);
        Task<string> DeleteProduct(int Id);
        Task<bool> IsProductExsists(int Id);
    }
}
