using Custom2d_Engine.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Combat
{
    public static class CombatManager
    {
        public static int PlayerHealth = 100;
        static MonstersManager monsterObject;
        static Random random = new Random();

        public static void InitCM(Hierarchy hierarchy)
        {
            monsterObject = new MonstersManager(hierarchy);
            monsterObject.ChangeMonster(1);
        }

        public static void HandleCardPlayed(Cards.Card card)
        {
            EliminateCommonAspects(card.aspects, 
                monsterObject.monsters[monsterObject.active].aspects);
        }

        private static void EliminateCommonAspects(Aspect[] cardA, Aspect[] monsterA)
        {
            for(int i = 0; i < cardA.Length; i++)
            {
                for(int j = 0; j < monsterA.Length; j++)
                {
                    if (cardA[i] == monsterA[j] && monsterA[j] != Aspects.NULL
                        && cardA[i] != Aspects.NULL)
                    {
                        monsterA[j] = Aspects.NULL;
                        Console.Out.WriteLine("Aspect was deleted");
                        break;
                    }
                }
            }

            bool isKill = true;
            foreach(Aspect aspect in monsterA) // check if monster is kill
            {
                if (!aspect.Equals(Aspects.NULL))
                {
                    isKill = false;
                    Console.Out.WriteLine("Monster's aspect is not null: " + aspect);
                }
            }

            if (isKill)
            {
                // what to do when monster is kill
                Console.Out.WriteLine("Monster is kill");
                monsterObject.ChangeMonster(random.Next(0, 2));
            }
        }
    }
}
