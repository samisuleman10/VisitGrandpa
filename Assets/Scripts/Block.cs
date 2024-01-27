using System;

namespace GrandpaVisit
{
    [Serializable]
    public class Block
    {
        public string text;
        public string headline;
        public string id;
        public Option[] options;
    }
}