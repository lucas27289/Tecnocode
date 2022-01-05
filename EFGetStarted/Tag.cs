using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace EFGetStarted
{
    [Index(nameof(TagName))]
    public class Tag 
    {
        public int TagId { get; set; }
        
        [MaxLength(50)]
        public string TagName { get; set; }
        
        public ICollection<Post> Posts {  get; set; }
    }
}