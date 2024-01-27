using System;

namespace GrandpaVisit
{
    [Serializable]
    public class Block
    {
        public Reaction[] Reactions;
        public string text;
        public int Unit;
        public string id;
        public Option[] Actions;
    }

    [Serializable]
    public class Reaction
    {
        public int minPointsIncl;
        public int maxPointsIncl;
        public string text;
    }
}