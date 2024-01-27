using Custom2d_Engine.Rendering.Sprites;
using JokeToKill.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Cards
{
    public static class Cards
    {
        public static Card Dad1 { get; private set; }
        public const string Dad1DescPath = "";

        public static Card Dad2 { get; private set; }
        public const string Dad2DescPath = "";

        public static Card Dad3 { get; private set; }
        public const string Dad3DescPath = "";

        public static Card[] AllCards { get; private set; }

        public static void Init()
        {
            Dad1 = new Card("Lorem Ipsum", Sprite.Empty, Aspects.Dad);
            Dad2 = new Card("Electric bogaloo", Sprite.Empty, Aspects.Dad, Aspects.Sad);
            Dad3 = new Card("Enigma", Sprite.Empty, Aspects.Sad);

            AllCards = new Card[] { Dad1, Dad2, Dad3 };
        }
    }
}
