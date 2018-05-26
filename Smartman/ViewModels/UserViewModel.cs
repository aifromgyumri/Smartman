using Smartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Username { get; set; }

        public int Rating { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public static UserModel ToModel(UserViewModel userViewModel)
        {
            var user = new UserModel
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Surname = userViewModel.Surname,
                Username = userViewModel.Username,
                Rating = userViewModel.Rating,
                Login = userViewModel.Login,
                Email = userViewModel.Email,
                Phone = userViewModel.Phone
            };
            return user;
        }

        public static UserViewModel ToViewModel(UserModel user)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Rating = user.Rating,
                Login = user.Login,
                Email = user.Email,
                Phone = user.Phone
            };
            return userViewModel;
        }
    }
}
