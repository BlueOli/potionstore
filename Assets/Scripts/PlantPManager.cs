using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PlantPManager : MonoBehaviour
{
    public GameObject plantPrefabContainer; // Reference to the parent GameObject holding plant prefabs
    public GameObject plantPrefab; // Reference to the PlantPrefab you created

    public List<PlantType> plantTypes; // Your list of PlantType objects

    [SerializeField]
    private Dictionary<string, int> plantQuantities = new Dictionary<string, int>();

    public Dictionary<string, int> PlantQuantities
    {
        get { return plantQuantities; }
    }

    void Start()
    {
        // Loop through the plant types and instantiate prefabs
        foreach (PlantType plantType in plantTypes)
        {
            // Instantiate a new plant prefab from the PlantPrefab
            GameObject newPlant = Instantiate(plantPrefab, plantPrefabContainer.transform);
            plantQuantities.Add(plantType.plantName, 0);
            newPlant.name = plantType.plantName;
            // Get the icon and quantity text components from the instantiated prefab
            Image iconImage = newPlant.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI quantityText = newPlant.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();

            // Set the icon and quantity text based on the PlantType data
            iconImage.sprite = plantType.plantIcon;
            quantityText.text = "0";
            //quantityText.text = GetPlantQuantity(plantType.plantName).ToString(); // Implement GetPlantQuantity function
            //Debug.Log(plantType.plantName + " cantidad: " + GetPlantQuantity(plantType.plantName) + " lista tipo: " + transform.parent.name);         
        }
    }

    int GetPlantQuantity(string plantName)
    {
        if (plantQuantities.ContainsKey(plantName))
        {
            return plantQuantities[plantName];
        }
        else
        {
            Debug.LogError("Plant name: " + plantName + "not found");
            return 0;
        }
    }

    void SetPlantQuantity(string plantName, int quantity)
    {
        plantQuantities[plantName] += quantity;
    }

    public void UpdatePlantQuantity(string plantName, int newQuantity)
    {
        // Update the plant quantity in the dictionary
        SetPlantQuantity(plantName, newQuantity);

        // Loop through the instantiated plant prefabs and update the quantity text
        foreach (Transform child in plantPrefabContainer.transform)
        {
            TextMeshProUGUI quantityText = child.Find("Quantity").GetComponent<TextMeshProUGUI>();

            // Check if the plant name matches the prefab's plant name
            if (child.name == plantName)
            {
                // Update the quantity text
                quantityText.text = plantQuantities[plantName].ToString();
                break; // Exit the loop after updating the quantity text
            }
        }
    }
}
