﻿using CI_PLATFORM.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_PLATFORM.Entities.ViewModels
{
    public class EditUserViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string? employeeId { get; set; }
        public string managerName { get; set; }
        public string title { get; set; }
        public string department { get; set; }
        public string profile { get; set; }
        public string whyIVolunteer { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
        public long cityId { get; set; }
        public long countryId { get; set; }
        public string availability { get; set; }
        public string linkedinURL { get; set; }
        public List<UserSkill> userSkills { get; set; }
        public List<Skill> skills { get; set; }

        [Required(ErrorMessage = "Enter Old Password")]
        public string oldpass { get; set; }

        [Required(ErrorMessage = "Enter New Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain atleast 1 lowercase,1 uppercase, 1 digit,1 special character and must be of 8 characters")]
        public string newpass { get; set; }

        [Required(ErrorMessage = "Enter ConfirmPassword")]
        [Compare("newpass", ErrorMessage = "Confirm Password is not match with Password")]
        public string confirmpass { get; set; }
    }
}
