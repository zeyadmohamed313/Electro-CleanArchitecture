using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface ICategoryServices
    {
         Task<string> AddCategory(Category category);
         Task<string> UpdateCategory(Category category);
         Task<string> DeleteCategory(int Id);
    }
}
