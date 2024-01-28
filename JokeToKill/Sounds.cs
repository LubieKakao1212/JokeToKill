using Custom2d_Engine.FMOD_Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill
{
    public static class Sounds
    {
        private static FSoundBank bank;

        public static FSound bee2;
        private static FSound phrog;
        private static FSound wasser;
        private static FSound alike;
        private static FSound sis;

        public static void Init(FMODSystem fmod)
        {
            bank = fmod.LoadBank("bank");
            bee2 = bank.GetSound("event:/Voice/(dad)(pun) 2bee");
            //phrog = bank.GetSound("event:/Voice/(dad) phrog");
            //wasser = bank.GetSound("event:/Voice/(dad)(pun) Wasser");
            //alike = bank.GetSound("event:/Voice/(MoM)(Dad) alike");
            //sis = bank.GetSound("event:/Voice/(MoM)(Pun) sis");

        }
    }
}