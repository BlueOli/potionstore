using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoldingPlant : MonoBehaviour
{
    public GameObject[] inventorySlots; // Array to store the child Plant GameObjects
    private GameObject cContainer; // Container that stores the childs Plant GameObjects

    private void Start()
    {
        cContainer = transform.GetChild(0).gameObject; // Get the first child of the HoldingPlant GameObject
        inventorySlots = new GameObject[cContainer.transform.childCount]; // Initialize the inventorySlots array with the number of childs of the HoldingPlant GameObject
        for (int i = 0; i < cContainer.transform.childCount; i++)
        {
            inventorySlots[i] = cContainer.transform.GetChild(i).gameObject; // Add each child of the HoldingPlant GameObject to the inventorySlots array
        }   
    }

    public void UpdateInventory()
    {
        // Check if there are available slots in the plant container
        foreach (GameObject slot in inventorySlots)
        {
            PlantType plantType = slot.GetComponent<PlantSlot>().PlantType;
            Image childImage = slot.GetComponentInChildren<Image>();
            TextMeshProUGUI childText = slot.GetComponentInChildren<TextMeshProUGUI>();
            childImage.sprite = plantType.plantIcon;

            
        }
    }
    /*
    // Function to add a plant or mushroom to the container based on plantID
    public void AddPlantToContainer(PlantType plantType)
    {
        if (plantType.typeID == 1)
        {
            // Check if there are available slots in the plant container
            foreach (GameObject slot in inventorySlots)
            {
                PlantSlot plantSlotScript = slot.GetComponent<PlantSlot>();
                if (!plantSlotScript.IsOccupied())
                {
                    plantSlotScript.SetPlantType(plantType);
                    return; // Exit the function after adding the plant
                }
            }
        }
        else if (plantType.typeID == 2)
        {
            // Check if there are available slots in the mushroom container
            foreach (GameObject slot in mushroomSlots)
            {
                MushroomSlot mushroomSlotScript = slot.GetComponent<MushroomSlot>();
                if (!mushroomSlotScript.IsOccupied())
                {
                    mushroomSlotScript.SetPlantType(plantType);
                    return; // Exit the function after adding the mushroom
                }
            }
        }
        else
        {
            Debug.LogError("Invalid plant type ID: " + plantType.typeID);
        }
    }
    */
}


