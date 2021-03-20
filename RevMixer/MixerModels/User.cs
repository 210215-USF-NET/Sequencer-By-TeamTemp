using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }
        public ICollection<Sample> Sample { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<UploadMusic> UploadMusics { get; set; }

        public ICollection<PlayList> PlayLists { get; set; }
    }
}