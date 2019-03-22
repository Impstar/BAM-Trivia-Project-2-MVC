using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ViewModels
{
    public class UsersViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Password")]
        public string PW { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        public long CreditCardNumber { get; set; }
        public int PointTotal { get; set; }
        public bool AccountType { get; set; }

    }
}
