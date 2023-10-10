using UnityEngine;
using UnityEngine.UI;


public class CropPot : MonoBehaviour
{
    public PlantType plantType;
    private bool isGrowing = false;
    private float growthTimer = 0f;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }

        // Add a listener to the button click event
        button.onClick.AddListener(CollectPlant);
    }


    void Update()
    {
        // Check if the crop pot is growing a plant
        if (isGrowing)
        {
            growthTimer += Time.deltaTime;

            // Check if the plant has grown completely
            if (growthTimer >= plantType.growTime)
            {
                // Plant is finished growing
                SetStatus("Finished");
                isGrowing = false;
            }
        }
    }

    /// <summary>
    /// Starts growing the plant
    /// </summary>
    public void StartGrowingPlant()
    {
        isGrowing = true;
        SetStatus("Growing");
    }

    /// <summary>
    /// Collects the plant from the crop pot and adds it to the player's inventory then resets the crop pot
    /// </summary>
    public void CollectPlant()
    {
        // Check if there is a plant in the crop pot and if it's either growing or finished growing
        if (plantType != null && !isGrowing )
        {
            // Perform collect action
            // TODO: Add the plant to the player's inventory, play a sound, etc.
            SetStatus("Collected");

            // Reset the crop pot for the next use
            ResetCropPot();
        }
        else
        {
            SetStatus("No plant or plant not ready");
        }
    }

    // Helper (for demonstration purposes)
    private void SetStatus(string status)
    {
        Debug.Log($"Crop Pot Status: {status}");
    }

    private void ResetCropPot()
    {
        plantType = null; 
        growthTimer = 0f;
        isGrowing = false;
        SetStatus("Empty");
    }
}


