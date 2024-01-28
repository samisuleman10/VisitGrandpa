using System;
using System.Collections.Generic;

namespace GrandpaVisit
{
    [Serializable]
    public class Block
    {
        private static Random rnd = new Random();

        public Reaction[] Reactions;
        //public string text;
        public int Unit = -1;
        public string id;
        public Option[] Actions;
        
        public Reaction GetReaction(int points)
        {
            List<Reaction> suitableReactions = new List<Reaction>();
            foreach (var reaction in Reactions)
            {
                if (reaction.minPointsIncl <= points && reaction.maxPointsIncl >= points)
                {
                    suitableReactions.Add(reaction);
                }
            }
            if (suitableReactions.Count > 0)
			{
                int index = rnd.Next(0, suitableReactions.Count);
                return suitableReactions[index];
			}
            return null;
        }
        
    }

    [Serializable]
    public class Reaction
    {
        public int minPointsIncl;
        public int maxPointsIncl;
        public string text;
    }
}