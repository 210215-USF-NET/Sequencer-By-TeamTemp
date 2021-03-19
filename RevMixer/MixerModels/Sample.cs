using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class Sample
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SampleName { get; set; }
        public string SampleLink { get; set; }

        public User User { get; set; }
        public ICollection<Track> Track { get; set; }
    }
}