using Electro.Data.Entites;
using Electro.Infrastructure.Abstracts;
using Electro.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.ServicesImplementations
{
    public class BlogServices : IblogServices
    {
        #region Fields
        private readonly IBlogRepository _blogRepository;
        #endregion

        #region Constructor
        public BlogServices(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;   
        }
        #endregion
        public async Task<string> AddBlog(Blog blog)
        {
            if (blog == null)
                return "Blog Is Not Found";
            
            await _blogRepository.AddAsync(blog);
            return "Success";
        }

        public async Task<string> DeleteBlog(int Id)
        {
            var blog = await _blogRepository.GetByIdAsync(Id);
            if (blog == null)
                return "Blog is not found";
            await _blogRepository.DeleteAsync(blog);
            return "Success";
        }

        public async Task<string> UpdateBlog(Blog blog)
        {
            if (blog == null)
                return "Blog is not found";

            await _blogRepository.UpdateAsync(blog);
            return "Success";
        }
    }
}
