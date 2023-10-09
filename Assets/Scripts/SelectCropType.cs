using UnityEngine;
using UnityEngine.UI;

public class SelectCropType : MonoBehaviour
{
    private Button button;
    private Image parentImage;

    void Start()
    {
        button = GetComponent<Button>();

        Transform cropHolder = transform.parent;
        parentImage = cropHolder.transform.parent.GetComponent<Image>();

        if (button == null)
        {
            Debug.LogError("Button component not found");
        }

        if (parentImage == null)
        {
            Debug.LogError("Parent GameObject doesn't have an Image component");
        }

        // Add a listener to the button on click event
        if (button != null) { button.onClick.AddListener(OnButtonClick); }
    }

    // Method to handle button click event
    void OnButtonClick()
    {
        if (parentImage != null)
        {
            parentImage.sprite = GetComponent<Image>().sprite;
        }
        else
        {
            Debug.LogWarning("Parent Image component not found!");
        }
        transform.parent.gameObject.SetActive(false);
    }
}


