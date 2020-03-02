using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthServiceHub
{
    public class User
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [Unique, NotNull]
        public string PhNumber { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public string Position { get; set; }
    }
}
