using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{    

    private PotionType potionType;
    private PlantType req1, req2, req3;
    public PlantPManager plantManager;
    public PlantPManager roomManager;
    private bool stopMaking = false;

    public bool StopMaking { get => stopMaking; set => stopMaking = value; }

    PotionType testPotion = new PotionType(PotionType.PotionTier.Tier1, new PlantType("Acorn", 1,1),1,"test","",1,1);

    private void MakePotionInternal(PotionType type)
    {
        potionType = type;
        DetermineRequirements(potionType);
        //CheckMaterials(potionType);
        WaitForMaterialAddition();
    }
    public void MakePotionTest()
    {
        potionType = testPotion;
        DetermineRequirements(potionType);
        //CheckMaterials(potionType);
        WaitForMaterialAddition();
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

    private bool CheckMaterials(PotionType pType)
    {
        switch (pType.type)
        {
            case PotionType.PotionTier.Tier1:
                if (HasEnoughMaterials(req1))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();

                    return true;
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            case PotionType.PotionTier.Tier2:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();
                    return true;
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            case PotionType.PotionTier.Tier3:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2) && HasEnoughMaterials(req3))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();
                    return true;
                }
                else{Debug.LogError("Not enough materials to make the potion.");}
                break;
            default:
                Debug.LogError("Invalid potion type!");
                break;
        }
        return false;
    }

    
    /// <summary>
    /// Checks if the player has enough materials to make the potion, then subtracts the materials from the player's inventory
    /// </summary>
    /// <param name="material"></param>
    /// <returns></returns>
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
        stopMaking = false;
        StartCoroutine(WaitForMaterialCoroutine());       
    }

    

    // Example coroutine for waiting
    private IEnumerator WaitForMaterialCoroutine()
    {
        Debug.Log("Waiting for material addition");
        while (!MaterialAddedToCaldreum())
        {
            if (stopMaking) { break;}
            yield return null;
        }
        if (stopMaking) { yield break; }
        WaitForMixing();
    }

    private bool MaterialAddedToCaldreum()
    {
        // Check if material has been added to caldreum        
        // Return true if added, false otherwise
        return CheckMaterials(potionType);
    }

    private void WaitForMixing()
    {
        // Wait for function "MixCaldreum" to be called
        StartCoroutine(WaitForMixingCoroutine());
    }
    private IEnumerator WaitForMixingCoroutine()
    {
        Debug.Log("Waiting for mixing");
        while (!MixCaldreum())
        {
            if (stopMaking) { break; }
            yield return null;
        }
        if (stopMaking) { yield break; }
        WaitForVessel();
    }

    private void WaitForVessel()
    {
        // Wait for function "AddToVessel" to be called
    }

    private bool MixCaldreum()
    {
        // Mixing logic
        // IF THE PLAYER DOES THE MINIGAME CORRECTLY
        if (null==null)
        {
            return true;
        }
        return false;
    }

    private void AddToVessel()
    {
        // Adding to vessel logic
        // Potion making process is complete
    }
}
