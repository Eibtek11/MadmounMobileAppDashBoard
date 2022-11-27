using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class ChatRoom
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
