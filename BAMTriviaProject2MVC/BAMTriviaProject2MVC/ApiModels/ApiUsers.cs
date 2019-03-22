using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.ApiModels
{
    public class ApiUsers
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pw { get; set; }
        public string Username { get; set; }
        public long? CreditCardNumber { get; set; }
        public int PointTotal { get; set; }
        public bool? AccountType { get; set; }
    }
}
