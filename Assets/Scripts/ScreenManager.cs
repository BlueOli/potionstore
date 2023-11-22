using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    #region Singleton   
    private static ScreenManager instance;
    public static ScreenManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScreenManager>();
                if (instance == null)
                {
                    GameObject playerObject = new GameObject("ScreenManager");
                    instance = playerObject.AddComponent<ScreenManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        // Ensure there's only one instance of the Player class
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Button[] screens;
    string hexColorCode = "#6064FA";
    ColorBlock pressedColor;
    UnityEngine.Color HLC ;
    UnityEngine.Color PC ;
    UnityEngine.Color SC ;
    UnityEngine.Color DC ;


    private void Start()
    {
         HLC = ColorUtils.HexToColor("#565AF0");
         PC = ColorUtils.HexToColor("#272DC3");
         SC = ColorUtils.HexToColor("#565AF0");
         DC = ColorBlock.defaultColorBlock.disabledColor;
        UnityEngine.Color newColor;
        if (UnityEngine.ColorUtility.TryParseHtmlString(hexColorCode, out newColor))
        {
            pressedColor = new ColorBlock { normalColor = newColor , highlightedColor = HLC, pressedColor = PC, selectedColor = SC, disabledColor = DC,colorMultiplier = 1, fadeDuration=0.1f};
            Button Store = GameObject.Find("Button_Lab").GetComponent<Button>();
            Store.colors = pressedColor;
        }
        else
        {
            Debug.LogError("Invalid Hex Color Code");
        }

    }

    public void ActiveScreen(GameObject go)
    {

        go.SetActive(true);
        ChangeButtonColor(go);

    }

    private void ChangeButtonColor(GameObject go)
    {       
        switch (go.name)
        {
            case "Store":
                screens[0].colors = pressedColor;
                screens[1].colors = ColorBlock.defaultColorBlock;
                screens[2].colors = ColorBlock.defaultColorBlock;
                break;
            case "Lab":
                screens[0].colors = ColorBlock.defaultColorBlock;
                screens[1].colors = pressedColor;
                screens[2].colors = ColorBlock.defaultColorBlock;
                break;
            case "Backyard":
                screens[0].colors = ColorBlock.defaultColorBlock;
                screens[1].colors = ColorBlock.defaultColorBlock;
                screens[2].colors = pressedColor;
                break;
            default:
                break;
        }
    }

    public void DeActiveScreen(GameObject go)
    {
        go.SetActive(false);
    }
}
