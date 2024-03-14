using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public enum Role
    {
        Admin,
        Racer
    }
    public partial class User
    {
        public User() 
        {
            Protocols = new HashSet<Protocol>();
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Protocol> Protocols { get; set; }
    }
}
