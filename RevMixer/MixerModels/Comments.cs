using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CommentData { get; set; }
        public int UserId { get; set; } //fk
        public int UploadMusicId { get; set; } //fk
    }
}