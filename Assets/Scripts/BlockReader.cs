using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GrandpaVisit
{
    public class BlockReader : MonoBehaviour
    {
        private Dictionary<string, Block> parsedBlocks = new Dictionary<string, Block>();
        private string inputFolder = "Assets/Resources/Blocks"; // Replace with your actual folder path

        private IEnumerator Start()
        {
            string[] files = Directory.GetFiles(inputFolder);
        
            foreach (string file in files)
            {
                yield return StartCoroutine(ReadBlockAsync(file));
            }

            // Now you have all the parsedBlocks ready
        }

        private IEnumerator ReadBlockAsync(string filePath)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    string jsonToRead = sr.ReadToEnd();
                    Debug.Log(jsonToRead);
                
                    Block block = JsonUtility.FromJson<Block>(jsonToRead);
                    parsedBlocks.Add(block.id, block);
                }
            }
            catch (IOException e)
            {
                Debug.LogError("Error reading file: " + e.Message);
            }

            yield return null; // Yield null to continue the loop
        }
    }
}

