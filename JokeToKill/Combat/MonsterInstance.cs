using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Scenes.Factory;
using JokeToKill.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Combat
{
    public class MonsterInstance : HierarchyObject
    {
        public String name;
        public Aspect[] aspects;
        public bool isAlive;
        private Sprite[] animationFrames;
        private Aspect[] aspectPool;

        private DrawableObject mainSprite;

        private DrawableObject[] aspectSprites;

        public MonsterInstance(String name, Sprite[] animationFrames, params Aspect[] aspectPool)
        {
            this.name = name;
            aspects = new Aspect[Constants.MaxMonsterAspects];
            this.animationFrames = animationFrames;

            this.aspectPool = aspectPool;

            var size = Sprites.GetSpriteSize(animationFrames[0]) * 2f;

            mainSprite = this.CreateDrawableChild(Sprite.Empty, localScale: size);
            mainSprite.Transform.GlobalPosition = new Vector2(Constants.MonsterFloorCenter.X, Constants.MonsterFloorCenter.Y + size.Y);

            CleanAspects();

            //RandomizeAspects();
        }

        private void CleanAspects()
        {
            for(int i = 0; i < aspects.Length; i++)
            {
                aspects[i] = Aspects.NULL;
            }
        }

        public void RandomizeAspects()
        {
            for (int i = 0; i < aspects.Length; i++)
            {
                aspects[i] = aspectPool[Random.Shared.Next(aspectPool.Length)];
                if (Random.Shared.Next(2) == 0)
                {
                    break;
                }
            }
        }

        public void Animate()
        {
            mainSprite.AnimateUnsynced(animationFrames, 0.1f);
        }

        protected override void RemovedFromScene()
        {
            base.RemovedFromScene();
        }
    }
}
