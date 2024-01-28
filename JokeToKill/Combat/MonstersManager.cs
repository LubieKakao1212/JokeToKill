using Custom2d_Engine.Scenes;
using JokeToKill.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JokeToKill.Combat
{
    public class MonstersManager
    {
        public MonsterInstance[] monsters = new MonsterInstance[3];
        public int active = -1;
        private Hierarchy hierarchy;

        public MonstersManager(Hierarchy hierarchy)
        {
            InitMonsters();
            this.hierarchy = hierarchy;
            //this.hierarchy.AddObject(monsters[active]);
            ChangeMonster(0);
            //monsters[active].AnimateUnsynced(monsters[active].animation, 0.1f);
        }

        public void PlayDeath()
        {
            monsters[active].PlayDead();
        }

        public void InitMonsters()
        {
            monsters[0] = new MonsterInstance("Minotaur", Sprites.MonsterMinotaur, Aspects.Daddy, Aspects.YoMama);
            monsters[1] = new MonsterInstance("Minotaur 2", Sprites.MonsterMinotaur, Aspects.Soviet, Aspects.Pun);
            monsters[2] = new MonsterInstance("Cthulhu", Sprites.MonsterCthulhu, Aspects.Pun);
            //monsters[0].aspects[0] = Aspects.YoMama;

            /*monsters[1] = new Monster("Mini Minotaur", Sprites.MonsterMinotaur);
            monsters[1].aspects[0] = Aspects.Daddy;
            monsters[1].Transform.GlobalPosition = new Vector2(3f, 3f);
            monsters[1].Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 1.2f;
            //monsters[1].animation = Sprites.MonsterMinotaur;*/
        }

        public void ChangeMonster(int index)
        {
            if (active >= 0)
            {
                hierarchy.RemoveObject(monsters[active]);
            }
            active = index;
            hierarchy.AddObject(monsters[active]);
            monsters[active].RandomizeAspects();
            monsters[active].Animate();
            Console.Out.WriteLine("Current monster is: " + monsters[active].name);
        }
    }
}
