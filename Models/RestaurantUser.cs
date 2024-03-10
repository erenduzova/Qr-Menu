using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenu.Models
{
    public class RestaurantUser
    {
        public int RestaurantId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
