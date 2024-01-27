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

        public static Sprite CardBG { get; private set; }
        private const string CardBGFile = "Sprites/Cards/CardBG";

        public static Sprite AspectDad { get; private set; }
        private const string AspectDadFile = "Sprites/Cards/Aspects/Dad";

        public static Sprite[] MonsterMinotaur { get; private set; }
        private const string MonseterMinotaurFile = "Sprites/Monsters/Minotaur";

        public static void Init(ContentManager content, SpriteAtlasLoader<Color> Loader)
        {
            CardFont = content.Load<SpriteFont>(CardFontFile);

            AspectDad = Loader.Load(AspectDadFile)[0];
            CardBG = Loader.Load(CardBGFile)[0];
            MonsterMinotaur = Loader.Load(MonseterMinotaurFile, 
                ArrayExtensions.Fill(new Rectangle[8], Slice(new Point(8 * 69, 96), new Point(1, 0), 8)));
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
