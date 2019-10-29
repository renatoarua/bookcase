using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class TabUser
    {
        public TabUser()
        {
            TabBook = new HashSet<TabBook>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFullName { get; set; }
        public DateTime? UserJoinDate { get; set; }

        public virtual ICollection<TabBook> TabBook { get; set; }
    }
}
