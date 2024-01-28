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
        public static FSound frog;
        public static FSound water;
        public static FSound alike;
        public static FSound sis;
        public static FSound equality;
        public static FSound cat_fix;
        public static FSound nom;
        public static FSound minotaur;
        public static FSound power;
        public static FSound thispear;
        public static FSound wholemole;
        public static FSound cliff;
        public static FSound jok;
        public static FSound start;
        public static FSound economy_fix;
        public static FSound longest;

        public static void Init(FMODSystem fmod)
        {
            bank = fmod.LoadBank("bank");
            bee2 = bank.GetSound("event:/Voice/2bee"); //dad, pun
            frog = bank.GetSound("event:/Voice/frog"); //dad
            water = bank.GetSound("event:/Voice/water"); //dad, pun
            alike = bank.GetSound("event:/Voice/alike"); //mom, dad
            sis = bank.GetSound("event:/Voice/sis"); //mom, pun
            equality = bank.GetSound("event:/Voice/equality"); //soviet, mom
            cat_fix = bank.GetSound("event:/Voice/cat_fix"); //mom
            nom = bank.GetSound("event:/Voice/nom"); //mom
            minotaur = bank.GetSound("event:/Voice/minotaur"); //pun
            power = bank.GetSound("event:/Voice/power"); //pun
            thispear = bank.GetSound("event:/Voice/thispear"); //pun
            wholemole = bank.GetSound("event:/Voice/wholemole"); //pun
            cliff = bank.GetSound("event:/Voice/cliff"); //soviet, dad
            jok = bank.GetSound("event:/Voice/jok"); //soviet
            start = bank.GetSound("event:/Voice/start"); //soviet
            economy_fix = bank.GetSound("event:/Voice/economy_fix"); //soviet
            longest = bank.GetSound("event:/Voice/longest"); //soviet

        }
    }
}