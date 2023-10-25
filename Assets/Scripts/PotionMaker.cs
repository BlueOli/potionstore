using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{    

    private PotionType potionType;
    private PlantType req1, req2, req3;
    public PlantPManager plantManager;
    public PlantPManager roomManager;

    public void MakePotion(PotionType type)
    {
        potionType = type;
        DetermineRequirements(potionType);
        CheckMaterials(potionType);
    }

    private void DetermineRequirements(PotionType pType)
    {
        switch (pType.type)
        {
            case PotionType.PotionTier.Tier1:
                req1 = pType.req1;                
                break;
            case PotionType.PotionTier.Tier2:
                req1 = pType.req1;
                req2 = pType.req2;
                break;
            case PotionType.PotionTier.Tier3:
                req1 = pType.req1;
                req2 = pType.req2;
                req3 = pType.req3;
                break;
            default:
                Debug.LogError("Invalid potion type!");
                break;
        }
    }

    private void CheckMaterials(PotionType pType)
    {
        switch (pType.type)
        {
            case PotionType.PotionTier.Tier1:
                if (HasEnoughMaterials(req1))
                {
                    // Wait for materials to be added to caldreum
                    WaitForMaterialAddition();
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            case PotionType.PotionTier.Tier2:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2))
                {
                    // Wait for materials to be added to caldreum
                    WaitForMaterialAddition();
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            case PotionType.PotionTier.Tier3:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2) && HasEnoughMaterials(req3))
                {
                    // Wait for materials to be added to caldreum
                    WaitForMaterialAddition();
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            default:
                Debug.LogError("Invalid potion type!");
                break;
        }
        
    }

    private bool HasEnoughMaterials(PlantType material)
    {
        if (material == null)
        {
            Debug.LogError("Not requerements on the potion req");
            return true;
        }

        if (material.typeID == 1)
        {
            if (plantManager.PlantQuantities.ContainsKey(material.plantName) && plantManager.GetPlantQuantity(material.plantName) > 0)
            {
                plantManager.UpdatePlantQuantity(material.plantName, -1);
                return true;
            }
        }
        else if (material.typeID == 2) 
        {
            if (roomManager.PlantQuantities.ContainsKey(material.plantName) && roomManager.GetPlantQuantity(material.plantName) > 0)
            {
                plantManager.UpdatePlantQuantity(material.plantName, -1);
                return true;
            }
        }
        
        return false;
    }

    private void WaitForMaterialAddition()
    {
        // Wait for function "AddedMaterialToCaldreum" to be called
        // For example, you can use coroutines or events to wait for the function call.
        // Coroutine example: StartCoroutine(WaitForMaterialCoroutine());
        // Event example: Define a custom event and wait for it to be raised.
    }

    private void WaitForMixing()
    {
        // Wait for function "MixCaldreum" to be called
    }

    private void WaitForVessel()
    {
        // Wait for function "AddToVessel" to be called
    }

    // Example coroutine for waiting
    private IEnumerator WaitForMaterialCoroutine()
    {
        while (!MaterialAddedToCaldreum())
        {
            yield return null;
        }

        WaitForMixing();
    }

    private bool MaterialAddedToCaldreum()
    {
        // Check if material has been added to caldreum
        // Return true if added, false otherwise
        return false;
    }

    private void MixCaldreum()
    {
        // Mixing logic
        WaitForVessel();
    }

    private void AddToVessel()
    {
        // Adding to vessel logic
        // Potion making process is complete
    }
}
