using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropType : MonoBehaviour
{
    public enum CropTypeEnum
    {
        Plant,
        Mushroom
    }
   
    public CropTypeEnum type = CropTypeEnum.Plant; // Default es tipo Plant 
}
