using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionType : MonoBehaviour
{
    public enum PotionTier
    {
        Tier1,
        Tier2,
        Tier3
    }
    
    public PotionTier type = PotionTier.Tier1; // Default es tipo Tier1

    public string Name;
    public string Description;
    public Sprite Image;
    public int Fame;
    public int Price;
    public PlantType req1;
    public PlantType req2;
    public PlantType req3;
    public int req1Amount;
    public int req2Amount;
    public int req3Amount;
}
