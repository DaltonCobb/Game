using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    class AudioPlayer
    {
        private static AudioPlayer instance = null;
        public static AudioPlayer Instance
        {
            get
            {
                instance = (instance == null) ? new AudioPlayer() : instance;
                return instance;
            }
        }

        Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();

        public void AddSound(string key, string filename)
        {
            sounds[key] = new SoundPlayer(@"../../Resources/Sounds/" + filename);
        }

        public void PlaySound(string key)
        {
            if(sounds.ContainsKey(key))
            {
                sounds[key].Play();
            }
        }
    }
}
