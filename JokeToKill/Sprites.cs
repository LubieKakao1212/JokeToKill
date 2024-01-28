using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Rendering.Sprites.Atlas;
using Custom2d_Engine.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JokeToKill
{
    public static class Sprites
    {
        public static SpriteFont CardFont { get; private set; }
        private const string CardFontFile = "CardsFont";

        public static Sprite SceneBG { get; private set; }
        private const string SceneBGFile = "Sprites/Background/BlackStripe";

        public static Sprite BagBG { get; private set; }
        private const string BagBGFile = "Sprites/Background/BagBG";
        
        public static Sprite BagFG { get; private set; }
        private const string BagFGFile = "Sprites/Background/BagFG";

        public static Sprite BattleBG { get; private set; }
        private const string BattleBGFile = "Sprites/Background/BattleBackGround";

        public static Sprite MonsterFloor { get; private set; }
        private const string MonsterFloorFile = "Sprites/Background/MonsterFloor";

        public static Sprite CardBG { get; private set; }
        private const string CardBGFile = "Sprites/Cards/CardBackground";

        public static Sprite AspectDad { get; private set; }
        private const string AspectDadFile = "Sprites/Cards/Aspects/Dad";

        public static Sprite AspectBad { get; private set; }
        private const string AspectBadFile = "Sprites/Cards/Aspects/Joker";

        public static Sprite AspectMom { get; private set; }
        private const string AspectMomFile = "Sprites/Cards/Aspects/Mom";

        public static Sprite AspectPun { get; private set; }
        private const string AspectPunFile = "Sprites/Cards/Aspects/Pun";

        public static Sprite AspectRussia { get; private set; }
        private const string AspectRussiaFile = "Sprites/Cards/Aspects/Russia";
        
        public static Sprite[] MonsterMinotaur { get; private set; }
        private const string MonseterMinotaurFile = "Sprites/Monsters/Minotaur";

        public static Sprite[] MonsterCthulhu { get; private set; }
        private const string MonsterCthulhuFile = "Sprites/Monsters/Cthulu";

        public static Sprite[] PlayerFull { get; private set; } // player without animations
        public static Sprite PlayerStatic { get; private set; } // 1-6 idle, 7 attack, 8-12 hurt, w:85, h:105
        public static Sprite[] PlayerIdle { get; private set; }
        public static Sprite[] PlayerAttack { get; private set; }
        public static Sprite[] PlayerHurt { get; private set; }
        private const string PlayerFile = "Sprites/Player";

        public static void Init(ContentManager content, SpriteAtlasLoader<Color> Loader)
        {
            CardFont = content.Load<SpriteFont>(CardFontFile);

            SceneBG = Loader.Load(SceneBGFile)[0];
            BagBG = Loader.Load(BagBGFile)[0];
            BagFG = Loader.Load(BagFGFile)[0];
            BattleBG = Loader.Load(BattleBGFile)[0];
            MonsterFloor = Loader.Load(MonsterFloorFile)[0];
            AspectDad = Loader.Load(AspectDadFile)[0];
            AspectBad = Loader.Load(AspectBadFile)[0];
            AspectMom = Loader.Load(AspectMomFile)[0];
            AspectPun = Loader.Load(AspectPunFile)[0];
            AspectRussia = Loader.Load(AspectRussiaFile)[0];
            CardBG = Loader.Load(CardBGFile)[0];
            MonsterMinotaur = Loader.Load(MonseterMinotaurFile, 
                ArrayExtensions.Fill(new Rectangle[8], Slice(new Point(8 * 69, 96), new Point(1, 0), 8)));
            MonsterCthulhu = Loader.Load(MonsterCthulhuFile,
                ArrayExtensions.Fill(new Rectangle[6], Slice(new Point(6 * 57, 92), new Point(1, 0), 6)));
            PlayerFull = Loader.Load(PlayerFile,
                ArrayExtensions.Fill(new Rectangle[12], Slice(new Point(12 * 85, 105), new Point(1, 0), 12)));
            PlayerStatic = PlayerFull[0];
            PlayerIdle = new Sprite[] { PlayerFull[0], PlayerFull[1], PlayerFull[2], PlayerFull[3], PlayerFull[4], PlayerFull[5], PlayerFull[6] };
        }

        public static Vector2 GetSpriteSize(Sprite sprite)
        {
            var pixel = Sprite.Empty.TextureRect.Width;
            return new Vector2(sprite.TextureRect.Width / pixel, sprite.TextureRect.Height / pixel) * Constants.Pixel;
        }

        public static Func<Rectangle> Slice(Point size, Point sliceDir, int sliceCount)
        {
            var sliceSize = (size * sliceDir);
            sliceSize = new Point(sliceSize.X / sliceCount, sliceSize.Y / sliceCount);
            var dirInv = new Point(1, 1) - sliceDir;
            var sliceSIzeInv = size * dirInv;
            var spriteSize = sliceSize + sliceSIzeInv;

            var i = new Reference<int>();
            return () =>
            {
                var i0 = i.Value++; 
                return new Rectangle(new Point(sliceSize.X * i0, sliceSize.Y * i0), spriteSize);
            };
        }

        private static int Mask(Point a, Point b)
        {
            var dot = a * b;
            return (dot.X + dot.Y);
        }
    }
}
