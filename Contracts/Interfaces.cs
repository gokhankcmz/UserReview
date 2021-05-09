using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
    { }

    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviews(bool trackChanges);
        IEnumerable<Review> GetReviews(ReviewStatus status, bool trackChanges);
        IEnumerable<Review> GetReviews(Guid userId, bool trackChanges);
    }

    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IReviewRepository Review { get; }
        void Save();
    }
}
