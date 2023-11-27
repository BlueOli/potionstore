using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CropPot : MonoBehaviour
{
    public PlantType plantType;
    private bool isGrowing = false;
    private float growthTimer = 0f;
    private Sprite defImage;
    private Image myImage;
    private bool canOpenTypes = true;
    public GameObject timerContainer;
    public Image timerClock;
    public Sprite[] timerSprites8;
    public Sprite[] timerSprites10;
    public Sprite[] timerSprites12;
    public Sprite[] timerSprites15;
    public Sprite[] timerSprites20;
    public GameObject checkMark;

    public bool CanOpenTypes { get => canOpenTypes; set => canOpenTypes = value; }

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
            
        }
        defImage = GetComponent<Image>().sprite;
        myImage = GetComponent<Image>();
        // Add a listener to the button click event
        button.onClick.AddListener(CollectPlant);
    }


    void Update()
    {
        // Check if the crop pot is growing a plant
        if (isGrowing)
        {
            if (timerContainer.activeSelf == false) timerContainer.SetActive(true);
            // Update the timer
            
            growthTimer += Time.deltaTime;
            switch (plantType.growTime)
            {
                case 8:
                    ClockOcho();
                    break;
                case 10:
                    ClockDiez();
                    break;
                case 12:
                    ClockDoce();                        
                    break;
                case 15:
                    ClockQuince();
                    break;
                case 20:
                    ClockVeinte();
                    break;
                default:
                    break;
            }            

            // Check if the plant has grown completely
            if (growthTimer >= plantType.growTime)
            {
                // Plant is finished growing
                SetStatus("Finished");
                checkMark.SetActive(true);
                isGrowing = false;
            }
        }else
        {
            timerContainer.SetActive(false);
        }
    }

    #region Clock animations
    private void ClockOcho()
    {
        if (growthTimer < 1)
        {
            timerClock.sprite = timerSprites8[0];
        }
        else if (growthTimer < 2)
        {
            timerClock.sprite = timerSprites8[1];
        }
        else if (growthTimer < 3)
        {
            timerClock.sprite = timerSprites8[2];
        }
        else if (growthTimer < 4)
        {
            timerClock.sprite = timerSprites8[3];
        }
        else if (growthTimer < 5)
        {
            timerClock.sprite = timerSprites8[4];
        }
        else if (growthTimer < 6)
        {
            timerClock.sprite = timerSprites8[5];
        }
        else if (growthTimer < 7)
        {
            timerClock.sprite = timerSprites8[6];
        }
        else if (growthTimer < 8)
        {
            timerClock.sprite = timerSprites8[7];
        }
    }
    
    private void ClockDiez()
    {
        if (growthTimer < 1)
        {
            timerClock.sprite = timerSprites10[0];
        }
        else if (growthTimer < 2)
        {
            timerClock.sprite = timerSprites10[1];
        }
        else if (growthTimer < 3)
        {
            timerClock.sprite = timerSprites10[2];
        }
        else if (growthTimer < 4)
        {
            timerClock.sprite = timerSprites10[3];
        }
        else if (growthTimer < 5)
        {
            timerClock.sprite = timerSprites10[4];
        }
        else if (growthTimer < 6)
        {
            timerClock.sprite = timerSprites10[5];
        }
        else if (growthTimer < 7)
        {
            timerClock.sprite = timerSprites10[6];
        }
        else if (growthTimer < 8)
        {
            timerClock.sprite = timerSprites10[7];
        }else if (growthTimer < 9)
        {
            timerClock.sprite = timerSprites10[8];
        }
        else if (growthTimer < 10)
        {
            timerClock.sprite = timerSprites10[9];
        }else if (growthTimer < 11)
        {
            timerClock.sprite = timerSprites10[10];
        }
    }

    private void ClockDoce() 
    {        
            if (growthTimer < 1)
            {
                timerClock.sprite = timerSprites12[0];
            }
            else if (growthTimer < 2)
            {
                timerClock.sprite = timerSprites12[1];
            }
            else if (growthTimer < 3)
            {
                timerClock.sprite = timerSprites12[2];
            }
            else if (growthTimer < 4)
            {
                timerClock.sprite = timerSprites12[3];
            }
            else if (growthTimer < 5)
            {
                timerClock.sprite = timerSprites12[4];
            }
            else if (growthTimer < 6)
            {
                timerClock.sprite = timerSprites12[5];
            }
            else if (growthTimer < 7)
            {
                timerClock.sprite = timerSprites12[6];
            }
            else if (growthTimer < 8)
            {
                timerClock.sprite = timerSprites12[7];
            }
            else if (growthTimer < 9)
            {
                timerClock.sprite = timerSprites12[8];
            }
            else if (growthTimer < 10)
            {
                timerClock.sprite = timerSprites12[9];
            }
            else if (growthTimer < 11)
            {
                timerClock.sprite = timerSprites12[10];
            }
            else if (growthTimer < 12)
            {
                timerClock.sprite = timerSprites12[11];
            }        
    }

    private void ClockQuince()
    {
        if (growthTimer < 1)
        {
            timerClock.sprite = timerSprites15[0];
        }
        else if (growthTimer < 2)
        {
            timerClock.sprite = timerSprites15[1];
        }
        else if (growthTimer < 3)
        {
            timerClock.sprite = timerSprites15[2];
        }
        else if (growthTimer < 4)
        {
            timerClock.sprite = timerSprites15[3];
        }
        else if (growthTimer < 5)
        {
            timerClock.sprite = timerSprites15[4];
        }
        else if (growthTimer < 6)
        {
            timerClock.sprite = timerSprites15[5];
        }
        else if (growthTimer < 7)
        {
            timerClock.sprite = timerSprites15[6];
        }
        else if (growthTimer < 8)
        {
            timerClock.sprite = timerSprites15[7];
        }
        else if (growthTimer < 9)
        {
            timerClock.sprite = timerSprites15[8];
        }
        else if (growthTimer < 10)
        {
            timerClock.sprite = timerSprites15[9];
        }
        else if (growthTimer < 11)
        {
            timerClock.sprite = timerSprites15[10];
        }
        else if (growthTimer < 12)
        {
            timerClock.sprite = timerSprites15[11];
        }else if (growthTimer < 13)
        {
            timerClock.sprite = timerSprites15[12];
        }
        else if (growthTimer < 14)
        {
            timerClock.sprite = timerSprites15[13];
        }
        else if (growthTimer < 15)
        {
            timerClock.sprite = timerSprites15[14];
        }else if(growthTimer < 16)
        {
            timerClock.sprite = timerSprites15[15];
        }
    }

    private void ClockVeinte()
    {
        if (growthTimer < 1)
        {
            timerClock.sprite = timerSprites20[0];
        }
        else if (growthTimer < 2)
        {
            timerClock.sprite = timerSprites20[1];
        }
        else if (growthTimer < 3)
        {
            timerClock.sprite = timerSprites20[2];
        }
        else if (growthTimer < 4)
        {
            timerClock.sprite = timerSprites20[3];
        }
        else if (growthTimer < 5)
        {
            timerClock.sprite = timerSprites20[4];
        }
        else if (growthTimer < 6)
        {
            timerClock.sprite = timerSprites20[5];
        }
        else if (growthTimer < 7)
        {
            timerClock.sprite = timerSprites20[6];
        }
        else if (growthTimer < 8)
        {
            timerClock.sprite = timerSprites20[7];
        }
        else if (growthTimer < 9)
        {
            timerClock.sprite = timerSprites20[8];
        }
        else if (growthTimer < 10)
        {
            timerClock.sprite = timerSprites20[9];
        }
        else if (growthTimer < 11)
        {
            timerClock.sprite = timerSprites20[10];
        }
        else if (growthTimer < 12)
        {
            timerClock.sprite = timerSprites20[11];
        }
        else if (growthTimer < 13)
        {
            timerClock.sprite = timerSprites20[12];
        }
        else if (growthTimer < 14)
        {
            timerClock.sprite = timerSprites20[13];
        }
        else if (growthTimer < 15)
        {
            timerClock.sprite = timerSprites20[14];
        }
        else if (growthTimer < 16)
        {
            timerClock.sprite = timerSprites20[15];
        }else if (growthTimer < 17)
        {
            timerClock.sprite = timerSprites20[16];
        }
        else if (growthTimer < 18)
        {
            timerClock.sprite = timerSprites20[17];
        }
        else if (growthTimer < 19)
        {
            timerClock.sprite = timerSprites20[18];
        }
        else if (growthTimer < 20)
        {
            timerClock.sprite = timerSprites20[19];
        }else if(growthTimer < 21)
        {
            timerClock.sprite = timerSprites20[20];
        }
    }

    #endregion

    /// <summary>
    /// Starts growing the plant
    /// </summary>
    public void StartGrowingPlant()
    {
        canOpenTypes = false;
        isGrowing = true;
        SetStatus("Growing");
    }

    /// <summary>
    /// Collects the plant from the crop pot and adds it to the player's inventory then resets the crop pot
    /// </summary>
    public void CollectPlant()
    {
        // Check if there is a plant in the crop pot and if it's either growing or finished growing
        if (plantType != null && !isGrowing )
        {
            // Perform collect action
            // TODO: Add the plant to the player's inventory, play a sound, etc.
            SetStatus("Collected");
            PlayerManager.Instance.AddMaterialToInventory(plantType);
            checkMark.SetActive(false);
            // Reset the crop pot for the next use
            ResetCropPot();
            myImage.sprite = defImage;
        }
        else
        {
            SetStatus("No plant or plant not ready");
        }
    }

    // Helper (for demonstration purposes)
    private void SetStatus(string status)
    {
        Debug.Log($"Crop Pot Status: {status}");
    }

    private void ResetCropPot()
    {
        plantType = null; 
        growthTimer = 0f;
        isGrowing = false;
        SetStatus("Empty");
        StartCoroutine(GrowPlant());
    }

    IEnumerator GrowPlant()
    {
        yield return new WaitForSeconds(0.2f);

        canOpenTypes = true;
    }
}


