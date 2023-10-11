using UnityEngine;
using UnityEngine.UI;
using static CropType;

public class DisplayCropType : MonoBehaviour
{
    GameObject objectToActivate;
    CropPot cropPot;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }
        cropPot = GetComponent<CropPot>();
        // Add a listener to the button click event
        button.onClick.AddListener(ActivateObject);

        objectToActivate = transform.GetChild(0).gameObject;
    }

    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            if (objectToActivate.activeSelf)
            {
                objectToActivate.SetActive(false);
            }
            else
            {
                if (cropPot.CanOpenTypes)
                {
                    objectToActivate.SetActive(true);

                    // Check the crop type
                    CropType cropType = objectToActivate.GetComponent<CropType>();

                    if (cropType != null)
                    {
                        Transform cropTypes = objectToActivate.transform.Find("CropTypes");

                        if (cropTypes != null)
                        {
                            cropTypes.gameObject.SetActive(!cropTypes.gameObject.activeSelf);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("CropType component not found");
                    }
                }
                
            }
        }
        else
        {
            Debug.LogWarning("Object to activate is not assigned");
        }
    }
}