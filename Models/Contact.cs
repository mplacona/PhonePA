using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;

namespace PhonePA.Models
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Declare that we want to use SQLite and name the database
			optionsBuilder.UseSqlite("Data Source=./contacts.db");
        }
    }
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Display(Name = "Contact Name")]
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
        [Display(Name = "Custom Message")]
        public string Message { get; set; }
        public bool Blocked { get; set; }
    }
}
