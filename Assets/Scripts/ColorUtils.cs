using UnityEngine;

public class ColorUtils : MonoBehaviour
{
    public static Color HexToColor(string hex)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            Debug.LogError("Invalid Hex Color Code");
            return Color.black; // Return a default color in case of an error
        }
    }

    // Example usage:
    void Start()
    {
        string hexCode = "#FF5733";
        Color color = HexToColor(hexCode);
        Debug.Log("Parsed Color: " + color);
    }
}

