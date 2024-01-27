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
        /*public static Card Dad1 { get; private set; }
        public const string Dad1DescPath = "";

        public static Card Dad2 { get; private set; }
        public const string Dad2DescPath = "";

        public static Card Dad3 { get; private set; }
        public const string Dad3DescPath = "";*/

        public static Card DadJoke_1 { get; private set; }
        public static Card DadJoke_2 { get; private set; }
        public static Card DadJoke_3 { get; private set; }
        public static Card DadJoke_4 { get; private set; }

        public static Card YoMama_1 { get; private set; }
        public static Card YoMama_2 { get; private set; }
        public static Card YoMama_3 { get; private set; }
        public static Card YoMama_4 { get; private set; }

        public static Card Soviet_1 { get; private set; }
        public static Card Soviet_2 { get; private set; }
        public static Card Soviet_3 { get; private set; }
        public static Card Soviet_4 { get; private set; }

        public static Card Pun_1 { get; private set; }
        public static Card Pun_2 { get; private set; }
        public static Card Pun_3 { get; private set; }
        public static Card Pun_4 { get; private set; }

        public static Card[] AllCards { get; private set; }

        public static void Init()
        {
            /*Dad1 = new Card("Lorem Ipsum", Sprite.Empty, Aspects.Dad);
            Dad2 = new Card("Electric bogaloo", Sprite.Empty, Aspects.Dad, Aspects.Sad);
            Dad3 = new Card("Enigma", Sprite.Empty, Aspects.Sad);*/

            DadJoke_1 = new Card("Dad1", Sprite.Empty, Aspects.Daddy);
            DadJoke_2 = new Card("Dad2", Sprite.Empty, Aspects.Daddy);
            DadJoke_3 = new Card("Dad3", Sprite.Empty, Aspects.Daddy);
            DadJoke_4 = new Card("Dad4", Sprite.Empty, Aspects.Daddy);

            YoMama_1 = new Card("YoMama1", Sprite.Empty, Aspects.YoMama);
            YoMama_2 = new Card("YoMama2", Sprite.Empty, Aspects.YoMama);
            YoMama_3 = new Card("YoMama3", Sprite.Empty, Aspects.YoMama);
            YoMama_4 = new Card("YoMama4", Sprite.Empty, Aspects.YoMama);

            Soviet_1 = new Card("Soviet1", Sprite.Empty, Aspects.Soviet);
            Soviet_2 = new Card("Soviet2", Sprite.Empty, Aspects.Soviet);
            Soviet_3 = new Card("Soviet3", Sprite.Empty, Aspects.Soviet);
            Soviet_4 = new Card("Soviet4", Sprite.Empty, Aspects.Soviet);

            Pun_1 = new Card("Pun1", Sprite.Empty, Aspects.Pun);
            Pun_2 = new Card("Pun2", Sprite.Empty, Aspects.Pun);
            Pun_3 = new Card("Pun3", Sprite.Empty, Aspects.Pun);
            Pun_4 = new Card("Pun4", Sprite.Empty, Aspects.Pun);

            AllCards = new Card[] { 
            DadJoke_1, DadJoke_2, DadJoke_3, DadJoke_4,
            YoMama_1, YoMama_2, YoMama_3, YoMama_4,
            Soviet_1, Soviet_2, Soviet_3, Soviet_4,
            Pun_1, Pun_2, Pun_3, Pun_4};
        }
    }
}
