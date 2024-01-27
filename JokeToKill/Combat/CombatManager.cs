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
        static MonsterObject monsterObject;

        public static void InitCM(Hierarchy hierarchy)
        {
            monsterObject = new MonsterObject(hierarchy);
            monsterObject.ChangeMonster(1);
        }

        public static void HandleCardPlayed(Cards.Card card)
        {

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
                        break;
                    }
                }
            }

            foreach(Aspect aspect in monsterA) // check if monster is kill
            {

            }
        }
    }
}
