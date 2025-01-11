using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IblogServices
    {
        Task<string> AddBlog(Blog blog);
        Task<string> UpdateBlog(Blog blog);
        Task<string> DeleteBlog(int Id);
    }
}
