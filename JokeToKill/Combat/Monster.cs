using Custom2d_Engine.Scenes.Drawable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Combat
{
    public class Monster : DrawableObject
    {
        public String name;
        public Aspect[] aspects;
        public Aspect[] currentAspects;
        public Custom2d_Engine.Rendering.Sprites.Sprite[] animation;
        public bool isAlive;

        public Monster(String name) : base(Color.White, 0f)
        {
            this.Color = Color.White;
            this.DrawOrder = 0f;
            this.name = name;
            aspects = new Aspect[Constants.MonsterAspects];
            currentAspects = new Aspect[Constants.MonsterAspects];
            CleanAspects(aspects);
            CleanAspects(currentAspects);
        }

        private void CleanAspects(Aspect[] aspects)
        {
            for(int i = 0; i < aspects.Length; i++)
            {
                aspects[i] = Aspects.NULL;
            }
        }

        public void ResetCurrentAspects()
        {
            for (int i = 0; i < aspects.Length; i++)
            {
                currentAspects[i] = aspects[i];
            }
        }

        public void SetAspects(params Aspect[] aspects)
        {
            this.aspects = aspects;
            ResetCurrentAspects();
        }
    }
}
