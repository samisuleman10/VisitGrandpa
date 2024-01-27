using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GrandpaVisit
{
    public class ParseClass 
    {
        public Dictionary<string, Block> ReadAllBlocks(string inputFolder)
        {
            Dictionary<string, Block> parsedBlocks = new Dictionary<string, Block>();
            var textAssets =  Resources.LoadAll<TextAsset>(inputFolder);
            foreach (var textAsset in textAssets)
            {
                Block block = JsonUtility.FromJson<Block>(textAsset.text);
                Debug.Log(block.id);
                parsedBlocks.Add(block.id, block);
            }
            return parsedBlocks;
        }
    }
}