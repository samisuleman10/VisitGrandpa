using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandpaVisit
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource[] audioSources;
        public float fadeSpeedUnitsPerSecond;

        private float[] volumeTarget = new float[] { 1, 0.8f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

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
                    switch(score)
					{
                        case -2:
                            volumeTarget = new float[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0.8f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0.4f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
					}
                    break;
                case 1:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 0.3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 0.3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                    }
                    break;
                case 2:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0.3f, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 1, 0.3f, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                    }
                    break;
                case 3:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 1, 0.3f, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0.3f, 1, 0.3f, 0, 0, 0, 0, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 };
                            break;
                    }
                    break;
                case 4:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 1, 0.3f, 0, 0, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0.3f, 1, 0.3f, 0, 0, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0.3f, 1, 0.3f, 0, 0, 0, 0 };
                            break;
                    }
                    break;
                case 5:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0.3f, 0, 0, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0.3f, 1, 0.3f, 0, 0 };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0.3f, 1, 0.3f, 0, 0 };
                            break;
                    }
                    break;
                case 6:
                    switch (score)
                    {
                        case -2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
                            break;
                        case -1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0.3f, 0 };
                            break;
                        case 0:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 };
                            break;
                        case 1:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0.3f, 1, 0.3f };
                            break;
                        case 2:
                            volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 };
                            break;
                    }
                    break;
                case 7:
                    volumeTarget = new float[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 };
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
