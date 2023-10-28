using UnityEngine;

[System.Serializable]
public class PlantType
{
    public Sprite plantIcon; 
    public string plantName; 
    public float growTime;
    public int typeID;

    public PlantType(string name, float time, int id)
    {
        plantName = name;
        growTime = time;
        typeID = id;
    }
}
