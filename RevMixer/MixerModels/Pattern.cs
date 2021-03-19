using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class Pattern
    {
        public int Id { get; set; }
        public string PatternData { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}