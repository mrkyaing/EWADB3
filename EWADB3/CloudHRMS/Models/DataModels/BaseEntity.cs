using CloudHRMS.Utilities;
using System.ComponentModel.DataAnnotations;
namespace CloudHRMS.Models.DataModels
{
    public abstract class BaseEntity
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public string IpAddress { get; set;}=NetworkHelper.GetLocalIPAddress(); 
    }
}
