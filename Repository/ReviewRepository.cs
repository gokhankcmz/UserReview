using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }


        public void CreateReview(Guid userId, Review review)
        {
            review.userId = userId;
            Create(review);
        }

        public IEnumerable<Review> GetReviews(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToList();
        public IEnumerable<Review> GetReviews(ReviewStatus status, bool trackChanges) =>
            FindAll(trackChanges).Where(c=> c.status == status)
            .OrderBy(c => c.CreatedAt)
            .ToList();


        public IEnumerable<Review> GetReviews(Guid userId, bool trackChanges) =>
            FindAll(trackChanges).Where(c=>c.userId.Equals(userId))
            .OrderBy(c => c.CreatedAt)
            .ToList();

        public Review GetReview(Guid reviewId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(reviewId), trackChanges).SingleOrDefault();

    }
}
