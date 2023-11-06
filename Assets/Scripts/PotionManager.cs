using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public GameObject potionPrefabContainer; // Reference to the parent GameObject holding potion prefabs
    public GameObject potionPrefab; // Reference to the PlantPrefab you created

    [SerializeField]
    private Dictionary<string, int> potionInventory = new Dictionary<string, int>(); // Dictionary to store crafted potions
    
    public List<PotionType> potionTypes; // Your list of PlantType objects


    public Dictionary<string, int> PotionInventory
    {
        get { return potionInventory; }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (PotionType potionType in potionTypes)
        {
            // Instantiate a new plant prefab from the PlantPrefab
            GameObject newPotion = Instantiate(potionPrefab, potionPrefabContainer.transform);
            potionInventory.Add(potionType.Name, 0);
            newPotion.name = potionType.Name;
            // Get the icon and quantity text components from the instantiated prefab
            Image iconImage = newPotion.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI quantityText = newPotion.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();

            // Set the icon and quantity text based on the PlantType data
            iconImage.sprite = potionType.Image;
            quantityText.text = "0";                   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetPotionQuantity(string plantName, int quantity)
    {
        potionInventory[plantName] += quantity;
    }
    public int GetPotionQuantity(string potionName)
    {
        if (potionInventory.ContainsKey(potionName))
        {
            return potionInventory[potionName];
        }
        else
        {
            Debug.LogError("Plant name: " + potionName + "not found");
            return 0;
        }
    }

    public void UpdatePotionQuantity(string potionName, int newQuantity)
    {
        // Update the plant quantity in the dictionary
        SetPotionQuantity(potionName, newQuantity);

        // Loop through the instantiated plant prefabs and update the quantity text
        foreach (Transform child in potionPrefabContainer.transform)
        {
            TextMeshProUGUI quantityText = child.Find("Quantity").GetComponent<TextMeshProUGUI>();

            // Check if the plant name matches the prefab's plant name
            if (child.name == potionName)
            {
                // Update the quantity text
                quantityText.text = potionInventory[potionName].ToString();
                break; // Exit the loop after updating the quantity text
            }
        }
    }


}
