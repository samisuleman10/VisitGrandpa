using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace GrandpaVisit
{
    public class FadeInFadeOutImage : MonoBehaviour
    {
        public Image imageFade;

        public float waitTime = 1f;

        void Start()
        {
            imageFade = GetComponent<Image>();
            FadeIn();
        }
        

        private void FadeIn()
        {
            StartCoroutine(FadeInCoroutine());
        }

        private IEnumerator FadeInCoroutine()
        {
            float elapsedTime = 0f;

            for (float alpha = 0f; alpha <= 1f; alpha += 0.005f)
            {
                    imageFade.color = new Color(1f, 1f, 1f, alpha);
                    yield return new WaitForSeconds(.01f);
            }

            yield return new WaitForSeconds(waitTime);
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            float elapsedTime = 0f;

            for (float alpha = 0f; alpha <= 1f; alpha += 0.005f)
            {
                imageFade.color = new Color(1f, 1f, 1f, 1f - alpha);
                yield return new WaitForSeconds(.01f);
            }
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
            // yield return new WaitForSeconds(waitTime);
        }
    }
}
