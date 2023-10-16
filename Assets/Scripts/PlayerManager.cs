using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
                if (instance == null)
                {
                    GameObject playerObject = new GameObject("Player");
                    instance = playerObject.AddComponent<PlayerManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        // Ensure there's only one instance of the Player class
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private List<PotionType> potionInventory = new List<PotionType>(); // List to store crafted potions
 

    private int fame = 0; // Player's fame attribute (starts at 0)

    public PlantPManager plantsManager;
    public PlantPManager mushroomsManager;

  
    /// <summary>
    /// Add a crafted potion to the potion inventory. It's going to be stored on a list of PotionType objects.
    /// </summary>
    /// <param name="potion"></param>
    public void AddPotionToInventory(PotionType potion)
    {
        potionInventory.Add(potion);
    }

    /// <summary>
    /// Remove a crafted potion from the potion inventory. It's going to be removed from the list of PotionType objects.
    /// </summary>
    /// <param name="potion"></param>
    public void RemovePotionFromInventory(PotionType potion)
    {
        // Remove a potion from the potion inventory.
        if (potionInventory.Contains(potion))
        {
            potionInventory.Remove(potion);
        }
        else
        {
            Debug.Log("Potion not found in inventory.");
        }
    }

    /// <summary>
    /// Add a material to the material inventory. It's going to be stored on a list of PlantType objects.
    /// </summary>
    /// <param name="plantType"></param>
    public void AddMaterialToInventory(PlantType plantType)
    {
        // Check the typeID and add the plant type to the appropriate inventory list
        if (plantType.typeID == 1)
        {
            plantsManager.UpdatePlantQuantity(plantType.plantName, 1);
        }
        else if (plantType.typeID == 2)
        {
            mushroomsManager.UpdatePlantQuantity(plantType.plantName, 1);
        }
        else
        {
            Debug.LogError("Invalid plant type ID: " + plantType.typeID);
        }
    }

    /// <summary>
    /// Remove a material to the material inventory. It's going to be removed from the list of PlantType objects.
    /// </summary>
    /// <param name="plantType"></param>
    public void RemoveMaterialFromInventory(PlantType plantType)
    {
        if (plantType.typeID == 1)
        {
            plantsManager.UpdatePlantQuantity(plantType.plantName, -1);
        }
        else if (plantType.typeID == 2)
        {
            mushroomsManager.UpdatePlantQuantity(plantType.plantName, -1);
        }
        else
        {
            Debug.LogError("Invalid plant type ID: " + plantType.typeID);
        }
    }

    public void IncreaseFame(int amount)
    {
        fame += amount;
    }

    public void DecreaseFame(int amount)
    {
        fame -= amount;
    }

    // Example Usage:
    // Player player = new Player();
    // Potion healthPotion = new Potion { Name = "Health Potion" };
    // PlantType herbs = new PlantType { Name = "Herbs" };
    // player.AddPotionToInventory(healthPotion);
    // player.AddMaterialToInventory(herbs);
    // player.IncreaseFame(10);
}

