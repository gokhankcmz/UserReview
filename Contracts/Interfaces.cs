using Entities;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }

    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(bool trackChanges);
        User GetUser(Guid userId, bool trackChanges);
        User GetUser(string userId, string password, bool trackChanges);
        IEnumerable<User> GetUsersAndAdmins(bool trackChanges);
        void CreateUser(User user);
    }

    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviews(bool trackChanges);
        IEnumerable<Review> GetReviews(ReviewStatus status, bool trackChanges);
        IEnumerable<Review> GetReviews(Guid userId, bool trackChanges);

        Review GetReview(Guid reviewId, bool trackChanges);

        void CreateReview(Guid userId, Review review);
    }

    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IReviewRepository Review { get; }
        void Save();
    }

    public interface IAuthenticationManager
    {
        string Authenticate(UserForAuthenticationDto userForAuth, IRepositoryManager repository);
    }
}
