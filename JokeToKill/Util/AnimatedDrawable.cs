using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Ticking;
using Custom2d_Engine.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Util
{
    public static class Animations
    {
        /// <summary>
        /// Do NOT call this method twice on the same object or things will break
        /// </summary>
        public static void AnimateUnsynced(this DrawableObject obj, Sprite[] frames, float frameDuration)
        {
            var frame = new Reference<int>();
            obj.AddAccurateRepeatingAction(() =>
            {
                obj.Sprite = frames[frame.Value = (frame + 1) % frames.Length];
            }, frameDuration);
        }
    }
}
