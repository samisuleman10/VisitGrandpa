using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandpaVisit
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource[] audioSources;
        public float fadeSpeedUnitsPerSecond;

        private float[] volumeTarget = new float[] { 1, 0, 0, 0 };

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            changeAudioSourceVolumes(Time.deltaTime * fadeSpeedUnitsPerSecond);
        }

        public void updateMusic(int unit, int score)
		{
            
            switch(unit)
			{
                case 0:
                    volumeTarget = new float[] { 1, Mathf.Max(0, score / 3f), 0, 0 };
                    break;
                case 1:
                    volumeTarget = new float[] { 1, Mathf.Max(0, 1 - score / 3f), Mathf.Max(0, score / 3f), 0 };
                    break;
            }
		}

        private void changeAudioSourceVolumes(float maxChangeAmount)
		{
            for (int i = 0; i < volumeTarget.Length; i++)
			{
                if (audioSources[i].volume > volumeTarget[i])
				{
                    float changeAmount = Mathf.Min(audioSources[i].volume - volumeTarget[i], maxChangeAmount);
                    audioSources[i].volume = audioSources[i].volume - changeAmount;
                    Debug.Log("called positive change by amount " + changeAmount);
                } else if (audioSources[i].volume < volumeTarget[i])
                {
                    float changeAmount = Mathf.Min(volumeTarget[i] - audioSources[i].volume, maxChangeAmount);
                    audioSources[i].volume = audioSources[i].volume + changeAmount;
                    Debug.Log("called negative change by amount " + changeAmount);
                }
            }
		}
    }
}
