using Custom2d_Engine.Scenes;
using Custom2d_Engine.Ticking;
using JokeToKill.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Combat
{
    public static class CombatManager
    {
        public static int PlayerHealth = 100;
        static MonstersManager monsterObject;
        static Random random = new Random();
        private static CardsObject cards;

        public static void InitCM(Hierarchy hierarchy, CardsObject cards)
        {
            monsterObject = new MonstersManager(hierarchy);
            monsterObject.ChangeMonster(1);
            CombatManager.cards = cards;
        }

        public static void HandleCardPlayed(Cards.Card card)
        {
            cards.Frozen = true;
            cards.AddActionSequence(HandlePlay(card));
        }

        public static IEnumerator<TimeSpan> HandlePlay(Card card)
        {
            card.voice.CreateInstance().Start();
            yield return card.voice.Duration;
            yield return EliminateCommonAspects(card.aspects,
                monsterObject.monsters[monsterObject.active]);
            cards.Frozen = false;
        }

        public static void AnimateCardPlayed()
        {

        }

        private static TimeSpan EliminateCommonAspects(Aspect[] cardA, MonsterInstance monster)
        {
            var monsterA = monster.aspects;
            for(int i = 0; i < cardA.Length; i++)
            {
                for(int j = 0; j < monsterA.Length; j++)
                {
                    if (cardA[i] == monsterA[j] && monsterA[j] != Aspects.NULL
                        && cardA[i] != Aspects.NULL)
                    {
                        monster.SetAspect(j, Aspects.NULL);//.Equals// = ;
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
                monsterObject.ChangeMonster(random.Next(0, Constants.MonsterCount));
                monsterObject.PlayDeath();

                return TimeSpan.FromSeconds(1f);
            }
            return TimeSpan.Zero;
        }
    }
}
