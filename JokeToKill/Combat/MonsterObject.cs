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
            monsters[0] = new Monster("Minotaur");
            monsters[0].aspects[0] = Aspects.YoMama;
            monsters[0].Transform.GlobalPosition = new Vector2(3f, 3f);
            monsters[0].Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 2f;
            monsters[0].animation = Sprites.MonsterMinotaur;

            monsters[1] = new Monster("Mini Minotaur");
            monsters[1].aspects[0] = Aspects.Daddy;
            monsters[1].Transform.GlobalPosition = new Vector2(3f, 3f);
            monsters[1].Transform.LocalScale = Sprites.GetSpriteSize(Sprites.MonsterMinotaur[0]) * 1.2f;
            monsters[1].animation = Sprites.MonsterMinotaur;
        }

        public void ChangeMonster(int index)
        {
            hierarchy.RemoveObject(monsters[active]);
            active = index;
            hierarchy.AddObject(monsters[active]);
            monsters[active].AnimateUnsynced(monsters[active].animation, 0.1f);
            Console.Out.WriteLine("Current monster is: " + monsters[active].name);
        }
    }
}
