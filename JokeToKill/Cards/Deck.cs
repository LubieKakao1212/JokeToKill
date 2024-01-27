using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeToKill.Cards
{
    public class Deck
    {
        private List<Card> defaultBucket;
        private List<Card> bucket;

        private Random random;

        public Deck(Card[] cards, int duplicates)
        {
            random = Random.Shared;
            defaultBucket = new List<Card>();
            for (int i = 0; i < duplicates; i++) 
            {
                defaultBucket.AddRange(cards);
            }
            bucket = new List<Card>();
            bucket.AddRange(defaultBucket);
        }

        public Card Get()
        {
            var i = random.Next(bucket.Count);
            var result = bucket[i];
            bucket.RemoveAt(i);
            if (bucket.Count == 0)
            {
                bucket.AddRange(defaultBucket);
            }

            return result;
        }
    }
}
