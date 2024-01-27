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
            NULL = new Aspect(Sprite.Empty, Color.Pink);
            Daddy = new Aspect(Sprites.AspectDad, Color.Yellow);
            YoMama = new Aspect(Sprites.AspectDad, Color.LightBlue);
            Soviet = new Aspect(Sprites.AspectDad, Color.Red);
            Pun = new Aspect(Sprites.AspectDad, Color.DarkGreen);
        }
    }

    public class Aspect
    {
        public Sprite Icon { get; private set; }

        public Color Tint { get; private set; }

        public Aspect(Sprite icon, Color tint) 
        {
            this.Icon = icon;
            this.Tint = tint;
        }
    }
}
