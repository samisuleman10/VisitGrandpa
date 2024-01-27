using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandpaVisit
{
    public class ParseClass
    {
        
    }

    [Serializable]
    public class Block
    {
        private string text;
        private string headline;
        private string id;
        private Option[] options;
    }
    
    [Serializable]
    public class Option
    {
        private string text;
        private string followup; //this is a block id
    }
}
