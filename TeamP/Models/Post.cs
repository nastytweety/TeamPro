using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TeamP.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string ProfilePic { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}