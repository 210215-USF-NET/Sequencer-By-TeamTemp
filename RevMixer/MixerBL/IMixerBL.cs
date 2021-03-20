using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixerModels;

namespace MixerBL
{
    public interface IMixerBL
    {

        public List<UploadMusic> GetUploadedMusicAsync();

        public List<User> GetUsersAsync();



    }
}
