using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PotionType 
{
    public enum PotionTier
    {
        Tier1,
        Tier2,
        Tier3
    }

    public PotionType(string name, int fame, int price)
    {
        Name = name;
        Fame = fame;
        Price = price;
    }

    private PotionTier type = PotionTier.Tier1; // Default es tipo Tier1

    public string Name;
    public Sprite Image;
    public int Fame;
    public int Price;

    private string description;
    private PlantType req1;
    private PlantType req2;
    private PlantType req3;
    private int req1Amount;
    private int req2Amount;
    private int req3Amount;

    public PlantType Req1 { get => req1; set => req1 = value; }
    public PlantType Req2 { get => req2; set => req2 = value; }
    public PlantType Req3 { get => req3; set => req3 = value; }
    public int Req1Amount { get => req1Amount; set => req1Amount = value; }
    public int Req2Amount { get => req2Amount; set => req2Amount = value; }
    public int Req3Amount { get => req3Amount; set => req3Amount = value; }
    public string Description { get => description; set => description = value; }
    public PotionTier Type { get => type; set => type = value; }

    public PotionType(PotionTier type, PlantType req1,int req1Amount,string name, string desc,int fame, int price)
    {
        this.Type = type;
        this.Req1 = req1;   
        this.Req1Amount = req1Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }

    public PotionType(PotionTier type, PlantType req1, PlantType req2, int req1Amount, int req2Amount, string name, string desc, int fame, int price)
    {
        this.Type = type;
        this.Req1 = req1;
        this.Req2 = req2;
        this.Req1Amount = req1Amount;
        this.Req2Amount = req2Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }

    public PotionType(PotionTier type, PlantType req1, PlantType req2, PlantType req3, int req1Amount, int req2Amount, int req3Amount, string name, string desc, int fame, int price)
    {
        this.Type = type;
        this.Req1 = req1;
        this.Req2 = req2;
        this.Req3 = req3;
        this.Req1Amount = req1Amount;
        this.Req2Amount = req2Amount;
        this.Req3Amount = req3Amount;
        this.Name = name;
        this.Description = desc;
        this.Fame = fame;
        this.Price = price;
    }
    
}
