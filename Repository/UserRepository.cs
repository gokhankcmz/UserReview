using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        //Get Users without admins
        public IEnumerable<User> GetUsers(bool trackChanges) =>
            FindByCondition(c=> c.userType.Equals(UserType.User), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToList();

        //Get Users with admins
        public IEnumerable<User> GetUsersAndAdmins(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToList();

        //with admins. because gets single entity
        public User GetUser(Guid userId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(userId), trackChanges)
            .SingleOrDefault();

        // Kullanıcının var olup olmadığını kontrol etmek için, AuthenticationManager içinde.
        public User GetUser(string username, string password, bool trackChanges) =>
            FindByCondition(c => c.username.Equals(username) && c.password.Equals(password), trackChanges)
            .SingleOrDefault();
        public void CreateUser(User user) => Create(user);


    }
}
