using System;
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
        public GameObject StartScreen;
        public GameObject GameScreen;
        public MusicManager musicManager;
        public Dictionary<string, Block> Blocks = new Dictionary<string, Block>();
        public TextTyper TextTyperSituation;
        public TextTyper TextTyperReaction;
        public int[] minPointRequirements;
        public string[] startIds;
        private string[] mainIds = new string[10];
        public int Points;
        private int totalPoints = 0;
        private int unit = 0;

        public GameObject ActionButtonPrefab;
        public Transform ActionButtonParent;
        GameObject actionButton;
        public double optionsTime = 0.8;
        
        public float waitTimeAfterSelection = 1.1f;
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
            GameScreen.SetActive(false);
        }
        
        private void Start()
        {
            StartScreen.SetActive(true);
            GameScreen.SetActive(false);
        }
        
        public void StartGame()
        {
            StartScreen.SetActive(false);
            GameScreen.SetActive(true);
            InitGame();
        }

        private void InitGame()
        {
            var parseClass = new ParseClass();
            Blocks = parseClass.ReadAllBlocks("Blocks");
            buildMainIds();
            TextTyperReaction.TypeText(". . .");
            StartCoroutine(DisplayBlock(startIds[0]));
        }
        
        private void RestartGame()
        {
            unit = 0;
            totalPoints = 0;
            Points = 0;
            StartGame();
        }

        private void Update()
        {
            // f1 to restart
            if (Input.GetKeyDown(KeyCode.F1))
            {
                RestartGame();
            }
        }

        private IEnumerator DelayBeforeDisplayBlocks(float seconds, string id , Option option)
        {
            yield return new WaitForSeconds(seconds);
            SetTextReaction(option.text);
            StartCoroutine(DisplayBlock(id));
        }

        private IEnumerator DisplayBlock(string id)
        {
            Debug.Log(id);
            
            if (actionButton!= null)
            {
                foreach (Transform child in ActionButtonParent)
                {
                    Destroy(child.gameObject);
                }
            }
            TextTyperSituation.TypeText("");
            yield return new WaitForSeconds(waitTimeAfterSelection);
            TextTyperSituation.TypeText(Blocks[id].GetReaction(Points).text);

            yield return new WaitUntil(() => !TextTyperSituation.IsTyping);

            float nextYPosition = 0;// TextTyperSituation.GetComponent<RectTransform>().rect.y - TextTyperSituation.GetComponent<RectTransform>().rect.height;
            foreach (var option in Blocks[id].Actions)
            {
                actionButton = Instantiate(ActionButtonPrefab, ActionButtonParent);
                actionButton.transform.position = new Vector2(100/*TextTyperSituation.GetComponent<RectTransform>().rect.x*/, nextYPosition + actionButton.GetComponent<RectTransform>().rect.height / 2);
                actionButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnActionClicked(option);
                });
                var textMesh = actionButton.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = option.text;
                
                Color c = textMesh.color;
                c.a = 0;
                textMesh.color = c;
            }
            
            foreach (Transform child in ActionButtonParent)
            {
                var textMesh = child.GetComponentInChildren<TextMeshProUGUI>();
                child.gameObject.SetActive(true);
                StartCoroutine(fadeInButton(textMesh));
                yield return new WaitUntil(() =>
                {
                    return textMesh.color.a >= optionsTime;
                });
            }
            
        }

        private IEnumerator fadeInButton(TextMeshProUGUI textMesh)
		{
            Color c = textMesh.color;
            for (float alpha = 0f; alpha <= 1; alpha += 0.01f)
            {
                c.a = alpha;
                textMesh.color = c;
                yield return new WaitForSeconds(.02f);
            }
        }
        
        private void OnActionClicked(Option option)
        {
            Debug.Log("Action clicked" + option.text);
            Points += option.points;
            if (Points < -2)
            {
                Points = -2;
            }
            musicManager.updateMusic(unit, Points);
            string id = "NONE";
            if (string.IsNullOrEmpty(option.followup))
            {
                if (checkUnitSwitched(Points))
                {
                    unit++;
                    totalPoints += Points;
                    Points = 0;
                    id = startIds[unit];
                }
                else
                {
                    id = getMainId(unit);
                }
                
            }
            else
            {
                id = option.followup;
            }
            var buttonIndex = 0;

            // some delay before displaying the next block
            StartCoroutine(DelayBeforeDisplayBlocks(waitTimeAfterSelection, id, option));
            
        }
        
        private void SetTextReaction(string text)
        {
            TextTyperReaction.TypeText(text);
        }

        private string getMainId(int unit)
        {
            return mainIds[unit];
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
                    Debug.Log(block.id + " -> " + block.Unit);
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

