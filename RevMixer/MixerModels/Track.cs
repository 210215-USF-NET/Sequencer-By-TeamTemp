using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class Track
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SampleId { get; set; }
        public int PatternId { get; set; }

        public Pattern Pattern { get; set; }
    }
}