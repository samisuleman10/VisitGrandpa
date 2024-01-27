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
            
            /*string[] files = Directory.GetFiles(inputFolder);
            foreach (string file in files)
            {
                Debug.Log(file);
                TextAsset targetFile = Resources.Load<TextAsset>("Blocks/" + Path.GetFileNameWithoutExtension(file));
                Block block = JsonUtility.FromJson<Block>(targetFile.text);
                parsedBlocks.Add(block.id, block);
            }*/
/*
                try
                {
                    using (var sr = new StreamReader(file))
                    {
                        // string jsonToRead = "{\"text\": \"Blub\", \"headline\": \"Blu\", \"id\": \"Bb\", \"options\": []}";//File.ReadAllText(file);
                        string jsonToRead = sr.ReadToEnd();
                        // string contentData = sr.ReadToEnd();
                        Debug.Log(jsonToRead);
                        
                        // json = System.Text.Encoding.UTF8.GetString(contentData.bytes, 3, contentData.bytes.Length - 3);
                        Block block = JsonUtility.FromJson<Block>(jsonToRead);
                        parsedBlocks.Add(block.id, block);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
  */          return parsedBlocks;
        }
        
        
    }
}