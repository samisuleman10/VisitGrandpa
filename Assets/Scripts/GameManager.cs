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
        public MusicManager musicManager;
        public Dictionary<string, Block> Blocks = new Dictionary<string, Block>();
        public TextTyper TextTyperSituation;
        public int[] minPointRequirements;
        public string[] startIds;
        public string[] mainIds = new string[6];
        public int Points;
        private int totalPoints = 0;
        private int unit = 0;

        public GameObject ActionButtonPrefab;
        public Transform ActionButtonParent;
        GameObject actionButton;
        public double optionsTime = 0.8;
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
            StartCoroutine(DisplayBlock(startIds[0]));
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
                
                //
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
            StartCoroutine(DisplayBlock(id));
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

