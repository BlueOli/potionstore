using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPotion : MonoBehaviour
{ 
    public PotionMaker potionMaker;
    public void StartPotionMakin(Image myImage)
    {
        Sprite mySprite = myImage.sprite;
        switch (mySprite.name)
        {
            case "HealthPotion":
                Debug.Log(mySprite.name);
                PotionType healthPotion = new PotionType(PotionType.PotionTier.Tier1, new PlantType("Acorn", 1, 1), 1, "HealthPotion", "Cura al que la tome", 1, 1);
                potionMaker.MakePotion(healthPotion);
                ClosePanel();
                break;
            case "LovePotion":
                Debug.Log(mySprite.name);
                PotionType lovePotion = new PotionType(PotionType.PotionTier.Tier1, new PlantType("Acorn", 1, 1), 1, "LovePotion", "Enamora al que la tome", 1, 1);
                potionMaker.MakePotion(lovePotion);
                ClosePanel();
                break;
            case "ManaPotion":
                Debug.Log(mySprite.name);
                PotionType manaPotion = new PotionType(PotionType.PotionTier.Tier2, new PlantType("Acorn", 1, 1), new PlantType("FrozenRoot", 1, 1), 1 ,1, "ManaPotion", "Restablece el mana del que la tome", 1, 1);
                potionMaker.MakePotion(manaPotion);
                ClosePanel();
                break;
            case "PoisonPotion":
                Debug.Log(mySprite.name);
                PotionType poisonPotion = new PotionType(PotionType.PotionTier.Tier3, new PlantType("Acorn", 1, 1), new PlantType("HardRoot", 1, 1), new PlantType("SpikeGlobe", 1, 1),1,1, 1, "PoisonPotion", "Envenena al que la tome", 1, 1);
                potionMaker.MakePotion(poisonPotion);
                ClosePanel();
                break;
            default:
                break;
        }
    }

    
    void ClosePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
