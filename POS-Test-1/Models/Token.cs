using System.ComponentModel.DataAnnotations;

namespace POS_Test_1.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
