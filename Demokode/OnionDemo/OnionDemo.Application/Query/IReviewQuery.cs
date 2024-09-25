using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Application.Query
{
    public interface IReviewQuery
    {
        ReviewDto GetReview(int reviewId);
        IEnumerable<ReviewDto> GetReviews(int accommodationId);
    }
}
