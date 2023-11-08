using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionMaker : MonoBehaviour
{

    private PotionType potionType;
    private PlantType req1, req2, req3;
    public PlantPManager plantManager;
    public PlantPManager roomManager;
    private bool stopMaking = false;
    public PotionManager potionManager;

    public bool StopMaking { get => stopMaking; set => stopMaking = value; }

    PotionType testPotion = new PotionType(PotionType.PotionTier.Tier1, new PlantType("Acorn", 1, 1), 1, "test", "", 1, 1);

    public void MakePotion(PotionType type)
    {
        potionType = type;
        DetermineRequirements(potionType);
        //CheckMaterials(potionType);
        isAdding = true;
        WaitForMaterialAddition();
    }
    /*public void MakePotionTest()
    {
        potionType = testPotion;
        DetermineRequirements(potionType);
        //CheckMaterials(potionType);
        WaitForMaterialAddition();
    }
    */

    private void DetermineRequirements(PotionType pType)
    {
        switch (pType.Type)
        {
            case PotionType.PotionTier.Tier1:
                req1 = pType.Req1;
                break;
            case PotionType.PotionTier.Tier2:
                req1 = pType.Req1;
                req2 = pType.Req2;
                break;
            case PotionType.PotionTier.Tier3:
                req1 = pType.Req1;
                req2 = pType.Req2;
                req3 = pType.Req3;
                break;
            default:
                Debug.LogError("Invalid potion type!");
                break;
        }
    }

    private bool CheckMaterials(PotionType pType)
    {
        switch (pType.Type)
        {
            case PotionType.PotionTier.Tier1:
                if (HasEnoughMaterials(req1))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();

                    return true;
                }
                else { Debug.LogError("Not enough materials to make the potion."); }
                break;
            case PotionType.PotionTier.Tier2:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();
                    return true;
                }
                else { Debug.LogError("Not enough materials to make the potion."); }
                break;
            case PotionType.PotionTier.Tier3:
                if (HasEnoughMaterials(req1) && HasEnoughMaterials(req2) && HasEnoughMaterials(req3))
                {
                    // Wait for materials to be added to caldreum
                    //WaitForMaterialAddition();
                    return true;
                }
                else { Debug.LogError("Not enough materials to make the potion."); }
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

    int tapCount = 0;
    public bool isMixed = false;
    bool isAdding = false;
    // Example coroutine for waiting
    private IEnumerator WaitForMaterialCoroutine()
    {
        tapCount = 0;
        Debug.Log("Waiting for material addition");
        while (!MaterialAddedToCaldreum())
        {
            if (stopMaking) { break; }
            yield return null;
        }
        if (stopMaking) { yield break; }
        WaitForMixing();
    }

    private bool MaterialAddedToCaldreum()
    {
        // Check if material has been added to caldreum
        if (isMixed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool isShaked;
    void Update()
    {
        HandleUserInput();
        if (isMixed)
        {
            isShaked = WaitingVesselShake();
        }
        
    }
    public Image slideMinigameOne;
    private void HandleUserInput()
    {
        //if (stopMaking) { return; }

        // Check for user taps
        if (Input.touchCount > 0 && isAdding)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Increment tapCount when the screen is tapped
                tapCount++;
                slideMinigameOne.fillAmount = tapCount / 5f;
                Debug.Log("Tap Count: " + tapCount);

                // Check if tapCount is greater than or equal to 5
                if (tapCount >= 5)
                {
                    isMixed = true;
                    Debug.Log("Mixed");
                    isAdding = false;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && isAdding)
        {
            // For editor testing: Increment tapCount when the mouse is clicked
            tapCount++;
            Debug.Log("Tap Count: " + tapCount);

            // Check if tapCount is greater than or equal to 5
            if (tapCount >= 5)
            {
                isMixed = true;
            }
        }
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
        StartCoroutine(WaitForVesselMix());
    }

    private IEnumerator WaitForVesselMix()
    {
        Debug.Log("Waiting for screenshake");
        while (!WaitingVessel())
        {
            if (stopMaking) { break; }
            yield return null;
        }
        if (stopMaking) { yield break; }
        AddToVessel();
    }
    private Vector3 previousAcceleration;
    private float shakeDetectionThreshold = 10;
    private bool WaitingVessel()
    {
        if (isShaked)
        {
            return true;
        }else
        {
            return false;
        }
    }
    private bool WaitingVesselShake()
    {
        // Get the current acceleration
        Vector3 currentAcceleration = Input.acceleration;

        // Calculate the magnitude of acceleration change
        float accelerationMagnitude = (currentAcceleration - previousAcceleration).magnitude;

        // If the acceleration change is above the threshold, consider it as screenshake
        if (accelerationMagnitude >= shakeDetectionThreshold)
        {
            // Screenshake detected!
            return true;
        }

        // Store the current acceleration for the next frame
        previousAcceleration = currentAcceleration;

        // No screenshake detected yet
        return false;
    }

    public bool isMixingDone = false;

    private bool MixCaldreum()
    {
        // Mixing logic
        // IF THE PLAYER DOES THE MINIGAME CORRECTLY
        if (isMixingDone)
        {
            
            return true;
        }
        return false;
    }

    private void AddToVessel()
    {
        // Adding to vessel logic
        // Potion making process is complete
        Debug.Log("Added Potion");
        potionManager.UpdatePotionQuantity(potionType.Name, 1);
    }
}
