using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Query.Results
{
    public class GetAllReviewsForProductResult
    {
        public string ReviewText {  get; set; }
        public UserResult User { get; internal set; }
    }
}
