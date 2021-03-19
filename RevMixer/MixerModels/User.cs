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
        public bool Admin { get; set; }

        public ICollection<SavedProject> SavedProjects { get; set; }
        public ICollection<Sample> Sample { get; set; }
    }
}