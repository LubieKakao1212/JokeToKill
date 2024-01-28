using Custom2d_Engine.Scenes;
using Custom2d_Engine.Scenes.Drawable;
using Custom2d_Engine.Scenes.Factory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Util
{
    public class SceneryObject : HierarchyObject
    {
        public SceneryObject() 
        {
            var size = Constants.CamSize * Constants.AspectVec;
            this.CreateDrawableChild(Sprites.SceneBG, localScale: size, drawOrder: -10f);
            this.CreateDrawableChild(Sprites.BattleBG, localScale: size, drawOrder: -2f);
            this.CreateDrawableChild(Sprites.BagBG, localScale: size, drawOrder: -1f);
            this.CreateDrawableChild(Sprites.BagFG, localScale: size, drawOrder: 10f);
            
            this.CreateDrawableChild(Sprites.MonsterFloor, 
                localScale: Sprites.GetSpriteSize(Sprites.MonsterFloor), 
                localPosition: Constants.MonsterFloorCenter);
        }
    }
}
