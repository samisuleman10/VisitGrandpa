using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrandpaVisit
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public Dictionary<string, Block> Blocks = new Dictionary<string, Block>();
        public TextTyper TextTyperSituation;
        public int[] minPointRequirements;
        public string[] startIds;
        public string[] mainIds = new string[6];
        public int Points;
        private int unit = 0;

        public GameObject ActionButtonPrefab;
        public Transform ActionButtonParent;
        GameObject actionButton;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                // DontDestroyOnLoad(gameObject);
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
            buildMainIds();
            DisplayBlock(startIds[0]);
        }

        private void DisplayBlock(string id)
        {
            Debug.Log(id);
            TextTyperSituation.TypeText(Blocks[id].GetReaction(Points).text);
            if (actionButton!= null)
            {
                foreach (Transform child in ActionButtonParent)
                {
                    Destroy(child.gameObject);
                }
            }

            foreach (var option in Blocks[id].Actions)
            {
                actionButton = Instantiate(ActionButtonPrefab, ActionButtonParent);
                actionButton.GetComponentInChildren<TextMeshProUGUI>().text = option.text;
                actionButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnActionClicked(option);
                });
            }
        }
        
        private void OnActionClicked(Option option)
        {
            Debug.Log("Action clicked" + option.text);
            Points += option.points;
            if (string.IsNullOrEmpty(option.followup))
            {
                if (checkUnitSwitched(Points))
                {
                    DisplayBlock(startIds[unit]);
                }
                else
                {
                    DisplayBlock(getMainId(Points));
                }
                
            }
            else
            {
                DisplayBlock(option.followup);
            }
        }

        private string getMainId(int points)
        {
            for (int i = 0; i < minPointRequirements.Length; i++)
            {
                if (points >= minPointRequirements[i])
                {
                    return mainIds[i];
                }
            }

            return null;
        }

        private bool checkUnitSwitched(int points)
        {
            if (points >= minPointRequirements[unit + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buildMainIds()
        {
            foreach (var block in Blocks.Values)
            {
                if (block.Unit >= 0)
                {
                    mainIds[block.Unit] = block.id;
                }
            }
        }

        private void GetJson()
        {
            Block myBlock = new Block
            {
                // text = "Example block text",
                Unit = 1,
                id = "block1",
                Reactions = new Reaction[]
                {
                    new Reaction { minPointsIncl = 0, maxPointsIncl = 10, text = "Reaction 1" },
                    new Reaction { minPointsIncl = 11, maxPointsIncl = 20, text = "Reaction 2" }
                },
                Actions = new Option[]
                {
                    new Option { text = "Option 1", followup = "block2", points = 5 },
                    new Option { text = "Option 2", followup = "block3", points = 10 }
                }
            };

            // Convert to JSON
            string json = JsonUtility.ToJson(myBlock);

            // Output the JSON string
            Debug.Log(json);
        }
    }
}

