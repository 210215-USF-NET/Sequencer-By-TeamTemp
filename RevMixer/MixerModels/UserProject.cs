using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class UserProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public bool Owner { get; set; }

        public User User { get; set; }
        public SavedProject SavedProject { get; set; }
    }
}