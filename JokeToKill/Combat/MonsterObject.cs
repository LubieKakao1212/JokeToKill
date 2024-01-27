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
    public class MonsterObject
    {
        public Monster[] monsters = new Monster[2];
        public int active = 0;
        private Hierarchy hierarchy;

        public MonsterObject(Hierarchy hierarchy)
        {
            InitMonsters();
            this.hierarchy = hierarchy;
            this.hierarchy.AddObject(monsters[active]);
            monsters[active].AnimateUnsynced(monsters[active].animation, 0.1f);
        }

        public void InitMonsters()
        {
            var m0 = new Monster("Minotaur");
            m0.SetAspects(Aspects.YoMama);
            m0.Transform.GlobalPosition = new Vector2(3f, 3f);
            m0.Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 2f;
            m0.animation = Sprites.MonsterMinotaur;
            monsters[0] = m0;

            var m1 = new Monster("Mini Minotaur");
            m0.SetAspects(Aspects.Daddy);
            m1.Transform.GlobalPosition = new Vector2(3f, 3f);
            m1.Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 1.2f;
            m1.animation = Sprites.MonsterMinotaur;
            monsters[1] = m1;

        }

        public void ChangeMonster(int index)
        {
            hierarchy.RemoveObject(monsters[active]);
            monsters[active].ResetCurrentAspects();
            active = index;
            hierarchy.AddObject(monsters[active]);
            monsters[active].AnimateUnsynced(monsters[active].animation, 0.1f);
            Console.Out.WriteLine("Current monster is: " + monsters[active].name);
        }
    }
}
