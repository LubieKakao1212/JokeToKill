using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Rendering.Sprites.Atlas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public static void Init(ContentManager content, SpriteAtlasLoader<Color> Loader)
        {
            CardFont = content.Load<SpriteFont>(CardFontFile);

            AspectDad = Loader.Load(AspectDadFile)[0];
            CardBG = Loader.Load(CardBGFile)[0];
        }

        public static Vector2 GetSpriteSize(Sprite sprite)
        {
            var pixel = Sprite.Empty.TextureRect.Width;
            return new Vector2(sprite.TextureRect.Width / pixel, sprite.TextureRect.Height / pixel) * Constants.Pixel;
        }

    }
}
