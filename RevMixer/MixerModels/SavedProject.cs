using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class SavedProject
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int BPM { get; set; }

        public ICollection<Track> Track { get; set; }
    }
}