using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GrandpaVisit
{
    public class NotifyOtherButtons : MonoBehaviour
    {
         public void NotifyClick()
        {
            var buttons = FindObjectsOfType<NotifyOtherButtons>();
            foreach (var button in buttons)
            {
                if (button != this) button.DisableOnNotClicked();
            }
        }

         private void DisableOnNotClicked()
         {
             GetComponent<Button>().interactable = false;
         }
    }
}
