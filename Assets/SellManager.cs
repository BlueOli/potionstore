using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI fameText;
    public TextMeshProUGUI potionQuote;
    public GameObject sellingContainer;
    public PotionManager potionManager;

    public Sprite[] potionImage;
    public Image potionSelling;

    int money = 0;
    int fame = 0;

    public Sprite[] sprites;
    public Image characterImage;

    public string[] quoteList; 
    public string[] potionList;

    string selectedPotion = "";

    // Randomly select a potion
    //string selectedPotion = potionList[Random.Range(0, potionList.Length)];

    void Start()
    {
        moneyText.text = money.ToString();
        fameText.text = fame.ToString();
        Sprite randomSprite = ChooseRandomSprite();
        if (randomSprite != null)
        { characterImage.sprite = randomSprite; }
        characterImage.gameObject.SetActive(false);
        CallClient();
    }

    public void UpdateUI()
    {
        moneyText.text = money.ToString();
        fameText.text = fame.ToString();
    }
    public void AddMoney(int amount)
    {
        money += amount;
        if (money < 0) { money = 0; }
        UpdateUI();
    }
    public void AddFame(int amount)
    {
        fame += amount;
        if (fame < 0) { fame = 0; }
        UpdateUI();
    }

    public void CallClient()
    {
        sellingContainer.SetActive(true);
        characterImage.gameObject.SetActive(true);
        SelectBuyer();
        selectedPotion = GetRandomPotion();
        SelectQuote(selectedPotion);
        SetPotionImage(selectedPotion);   
    }

    private Sprite ChooseRandomSprite()
    {
        if (sprites == null || sprites.Length == 0)
        { Debug.LogError("Sprite array is empty or null!"); return null; }

        int randomIndex = Random.Range(0, sprites.Length);
        return sprites[randomIndex];
    }

    public void SelectBuyer()
    {
        Sprite randomSprite = ChooseRandomSprite();
        if (randomSprite != null) { characterImage.sprite = randomSprite; }
    }

    void SelectQuote(string potionName)
    {
        // Check if there are quotes and potions available
        if (quoteList.Length > 0 && potionList.Length > 0)
        {
            // Randomly select a quote
            string selectedQuote = quoteList[Random.Range(0, quoteList.Length)];   
            string updatedQuote = ReplacePotionName(selectedQuote, potionName);
            selectedQuote = updatedQuote;            

            if (potionQuote != null) { potionQuote.text = selectedQuote; }
            else { Debug.LogError("TextMeshPro reference is not set!"); }
        }
        else { Debug.LogError("No quotes or potions available!"); }
    }

    string ReplacePotionName(string dialog, string potionType)
    {
        return dialog.Replace("%potionName%", potionType);
    }

    string GetRandomPotion()
    {
        if (potionList.Length > 0)
        {
            int randomIndex = Random.Range(0, potionList.Length);
            return potionList[randomIndex];
        }
        else { return "No potions available"; }
    }

    void SetPotionImage(string potionName)
    {
        switch (potionName)
        {
            case "HealthPotion":
                potionSelling.sprite = potionImage[0];
                break;
            case "LovePotion":
                potionSelling.sprite = potionImage[1];
                break;
            case "ManaPotion":
                potionSelling.sprite = potionImage[2];
                break;
            case "PoisonPotion":
                potionSelling.sprite = potionImage[3];
                break;
            default:
                break;
        }

    }

    public void DeclineButton()
    {
        sellingContainer.SetActive(false);
        AddFame(-1);
        StartCoroutine(WaitForClient());
    }

    IEnumerator WaitForClient()
    {
        yield return new WaitForSeconds(5);
        CallClient();
    }

    public void SellButton()
    {     
        if(potionManager.GetPotionQuantity(selectedPotion) > 0)
        {
            potionManager.UpdatePotionQuantity(selectedPotion, -1);
            AddMoney(GetPotionPrice(selectedPotion));
            AddFame(GetPotionFame(selectedPotion));
            sellingContainer.SetActive(false);
            StartCoroutine(WaitForClient());
        }
        else
        {
            Debug.LogError("No potions available!");
        }
        
    }

    int GetPotionPrice(string potionName)
    {
        switch (potionName)
        {
            case "HealthPotion":
                return 10;
            case "LovePotion":
                return 20;
            case "ManaPotion":
                return 30;
            case "PoisonPotion":
                return 40;
            default:
                return 0;
        }
    }

    int GetPotionFame(string potionName)
    {
        switch (potionName)
        {
            case "HealthPotion":
                return 1;
            case "LovePotion":
                return 2;
            case "ManaPotion":
                return 3;
            case "PoisonPotion":
                return 4;
            default:
                return 0;
        }
    }


}
