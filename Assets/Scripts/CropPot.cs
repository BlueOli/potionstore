using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CropPot : MonoBehaviour
{
    public PlantType plantType;
    private bool isGrowing = false;
    private float growthTimer = 0f;
    private Sprite defImage;
    private Image myImage;
    private bool canOpenTypes = true;

    public bool CanOpenTypes { get => canOpenTypes; set => canOpenTypes = value; }

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }
        defImage = GetComponent<Image>().sprite;
        myImage = GetComponent<Image>();
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
        canOpenTypes = false;
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
            myImage.sprite = defImage;
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
        StartCoroutine(GrowPlant());
    }

    IEnumerator GrowPlant()
    {
        yield return new WaitForSeconds(0.2f);

        canOpenTypes = true;
    }
}


