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

    public PotionType(PotionTier type, PlantType req1,int req1Amount,string name, string desc,int fame, int price)
    {
        this.type = type;
        this.req1 = req1;   
        this.req1Amount = req1Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }

    public PotionType(PotionTier type, PlantType req1, PlantType req2, int req1Amount, int req2Amount, string name, string desc, int fame, int price)
    {
        this.type = type;
        this.req1 = req1;
        this.req2 = req2;
        this.req1Amount = req1Amount;
        this.req2Amount = req2Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }

    public PotionType(PotionTier type, PlantType req1, PlantType req2, PlantType req3, int req1Amount, int req2Amount, int req3Amount, string name, string desc, int fame, int price)
    {
        this.type = type;
        this.req1 = req1;
        this.req2 = req2;
        this.req3 = req3;
        this.req1Amount = req1Amount;
        this.req2Amount = req2Amount;
        this.req3Amount = req3Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }
}
