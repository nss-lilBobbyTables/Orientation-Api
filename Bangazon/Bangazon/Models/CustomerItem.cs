using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class CustomerItem
    {
        public int Customer_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int isActive { get; set; }
    }
}