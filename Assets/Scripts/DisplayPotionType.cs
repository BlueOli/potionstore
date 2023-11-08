using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayPotionType : MonoBehaviour
{

    public void ActivateObject(GameObject objectToActivate)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
        else
        {
            Debug.LogWarning("Object to activate is not assigned");
        }
    }
}
