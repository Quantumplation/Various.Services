﻿using System.ComponentModel.DataAnnotations;
using Website.Models;

namespace Website.ViewModels.Web
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }

        public RegisterViewModel(User fromUser)
        {
            UserName = fromUser.UserName;
        }

        public User ToUser()
        {
            return new User
            {
                UserName = UserName,
            };
        }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Invite Key")]
        public string InviteKey { get; set; }
    }
}