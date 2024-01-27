using Custom2d_Engine.Rendering.Sprites;
using Microsoft.Xna.Framework;

namespace JokeToKill.Combat
{
    public static class Aspects
    {
        public static Aspect NULL { get; private set; }
        public static Aspect Dad { get; private set; }
        public static Aspect Sad { get; private set; }

        public static void Init() 
        {
            NULL = new Aspect(Sprite.Empty, Color.White);
            Dad = new Aspect(Sprites.AspectDad, Color.White);
            Sad = new Aspect(Sprites.AspectDad, Color.DarkRed);
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
