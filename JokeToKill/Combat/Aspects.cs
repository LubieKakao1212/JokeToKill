using Custom2d_Engine.Rendering.Sprites;
using Microsoft.Xna.Framework;

namespace JokeToKill.Combat
{
    public static class Aspects
    {
        public static Aspect NULL { get; private set; }
        public static Aspect Daddy { get; private set; }
        public static Aspect YoMama { get; private set; }
        public static Aspect Soviet { get; private set; }
        public static Aspect Pun { get; private set; }

        public static void Init() 
        {
            NULL = new Aspect(Sprite.Empty, Color.Transparent, nameof(NULL));
            Daddy = new Aspect(Sprites.AspectDad, Color.White, nameof(Daddy));
            YoMama = new Aspect(Sprites.AspectMom, Color.White, nameof(YoMama));
            Soviet = new Aspect(Sprites.AspectRussia, Color.White, nameof(Soviet));
            Pun = new Aspect(Sprites.AspectPun, Color.White, nameof(Pun));
        }
    }

    public class Aspect
    {
        public Sprite Icon { get; private set; }

        public Color Tint { get; private set; }

        public string DebugName { get; private set; }

        public Aspect(Sprite icon, Color tint, string debugName)
        {
            this.Icon = icon;
            this.Tint = tint;
            this.DebugName = debugName;
        }

        public override string ToString()
        {
            return DebugName;
        }
    }
}
