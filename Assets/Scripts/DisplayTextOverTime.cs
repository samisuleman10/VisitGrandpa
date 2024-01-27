using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GrandpaVisit
{
    public class DisplayTextOverTime : MonoBehaviour
    {
        private TMP_Text tmpText;
        public string fullText;
        private string currentText = "";
        public float delay = 0.05f; // Delay between each character

        void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        void Start()
        {
            if (tmpText != null)
            {
                StartCoroutine(ShowText());
            }
        }

        IEnumerator ShowText()
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i + 1);
                tmpText.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}

