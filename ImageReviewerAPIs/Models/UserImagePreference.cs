using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageReviewerAPIs.Models
{
    public class UserImagePreference
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public Nullable<bool> Preference { get; set; }


        public string ImagePath { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
    }
}
