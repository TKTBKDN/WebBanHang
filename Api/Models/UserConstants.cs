using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "a", EmailAddress = "jason.admin@email.com", Password = "a", GivenName = "Jason", Surname = "Bryant", Role = "Administrator" },
            new UserModel() { Username = "elyse_seller", EmailAddress = "elyse.seller@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Lambert", Role = "Seller" },
        };
    }
}
