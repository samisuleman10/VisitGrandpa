using System;

namespace GrandpaVisit
{
    [Serializable]
    public class Block
    {
        public Reaction[] Reactions;
        //public string text;
        public int Unit = -1;
        public string id;
        public Option[] Actions;
        
        public Reaction GetReaction(int points)
        {
            foreach (var reaction in Reactions)
            {
                if (reaction.minPointsIncl <= points && reaction.maxPointsIncl >= points)
                {
                    return reaction;
                }
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