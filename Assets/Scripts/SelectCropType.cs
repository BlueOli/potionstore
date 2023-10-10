using UnityEngine;
using UnityEngine.UI;

public class SelectCropType : MonoBehaviour
{
    private Button button;
    private Image parentImage;
    private CropPot cropPot;
    public PlantType myPlantType;

    public PlantType MyPlantType { get => myPlantType; set => myPlantType = value; }

    void Start()
    {
        button = GetComponent<Button>();

        Transform cropHolder = transform.parent;
        parentImage = cropHolder.transform.parent.GetComponent<Image>();
        cropPot = cropHolder.transform.parent.GetComponent<CropPot>();
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

    public void SetCrop(PlantType plant)
    {
        cropPot.plantType = plant;
        cropPot.StartGrowingPlant();
    }

    // Method to handle button click event
    void OnButtonClick()
    {
        if (parentImage != null)
        {
            parentImage.sprite = GetComponent<Image>().sprite;
            SetCrop(myPlantType);
        }
        else
        {
            Debug.LogWarning("Parent Image component not found!");
        }
        transform.parent.gameObject.SetActive(false);
    }
}


