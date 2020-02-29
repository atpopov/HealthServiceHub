using System;
using System.Collections.Generic;
using System.Text;

namespace HealthServiceHub
{
    class User
    {

        public User(string id, string password)
        {
            this.Password = password;
            this.Id = id;
        }
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
