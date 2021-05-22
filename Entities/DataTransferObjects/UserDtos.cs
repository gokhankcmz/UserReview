using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public UserType userType { get; set; }
    }
    public class UserDtoForCreation
    {
        private Guid id = new Guid();
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        public UserType userType = UserType.User;
    }
}
