using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandpaVisit
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public Dictionary<string, Block> Blocks = new Dictionary<string, Block>();
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            var parseClass = new ParseClass();
            Blocks = parseClass.ReadAllBlocks("Blocks");
        }
    
    }
}

