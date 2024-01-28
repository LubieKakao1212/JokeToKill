using Custom2d_Engine.Rendering.Sprites;
using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Scenes.Factory;
using Custom2d_Engine.Ticking;
using Custom2d_Engine.Util;
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
        private Sprite dead;
        private Aspect[] aspectPool;

        private DrawableObject mainSprite;
        private DrawableObject deadSprite;

        private DrawableObject[] aspectSprites;

        public MonsterInstance(string name, Sprite[] animationFrames, Sprite dead, params Aspect[] aspectPool)
        {
            this.name = name;
            aspects = new Aspect[Constants.MaxMonsterAspects];
            this.animationFrames = animationFrames;

            this.dead = dead;
            deadSprite = this.CreateDrawableChild(dead, localScale: Sprites.GetSpriteSize(dead) * 2f);


            this.aspectPool = aspectPool;

            var size = Sprites.GetSpriteSize(animationFrames[0]) * 2f;

            mainSprite = this.CreateDrawableChild(Sprite.Empty, localScale: size);
            mainSprite.Transform.GlobalPosition = new Vector2(Constants.MonsterFloorCenter.X, Constants.MonsterFloorCenter.Y + size.Y);
            
            aspectSprites = new DrawableObject[Constants.MaxMonsterAspects];
            var offset = new Vector2(0f, -size.Y / 10);

            for (int i = 0; i < aspectSprites.Length; i++)
            {
                aspectSprites[i] = this.CreateDrawableChild(Sprite.Empty,
                    localPosition: new Vector2(-size.X, size.Y) + offset * (i * 2f + 2f),
                    localScale: new Vector2(1f));
                aspectSprites[i].Transform.GlobalPosition += mainSprite.Transform.GlobalPosition;
            }

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
            SetAspects(aspects);
        }

        public void Animate()
        {
            var frame = new Reference<int>();
            mainSprite.Color = Color.White;
            deadSprite.Color = Color.Transparent;
            this.AddAccurateRepeatingAction(() =>
            {
                mainSprite.Sprite = animationFrames[frame.Value = (frame + 1) % animationFrames.Length];
            }, 0.1f);
        }

        private void SetAspects(Aspect[] aspects)
        {
            for (int i = 0; i < this.aspects.Length; i++)
            {
                if (i < aspects.Length)
                {
                    SetAspect(i, aspects[i]);
                }
                else
                {
                    SetAspect(i, Aspects.NULL);
                }
            }
        }

        public void SetAspect(int i, Aspect aspect)
        {
            aspectSprites[i].Sprite = aspect.Icon;
            aspectSprites[i].Color = aspect.Tint;
            aspectSprites[i].Transform.LocalScale = Sprites.GetSpriteSize(aspect.Icon);
            aspects[i] = aspect;
        }

        public void PlayDead() 
        {
            //CurrentHierarchy.TickManager.RemoveAllTickers(this);
            deadSprite.Color = Color.White;
            mainSprite.Color = Color.Transparent;
        }

    }
}
