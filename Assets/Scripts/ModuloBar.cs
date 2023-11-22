using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuloBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;

    [SerializeField] int maxTier = 6; //max amount per tier, always set this value to the visual bar + 1
    [SerializeField] int statValue = 0; //your real progress value

    void Start()
    {
        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        progressBar.value = statValue % maxTier; //Increase the bar value using modulo, so it resets when reach the max tier amount
    }

    //Method for increasing progress
    public void IncreaseProgress()
    {
        statValue++;
        UpdateProgressBar();
    }

    //Method for decreasing progress, and clamp the value, so it doesn't go below the minimum value (in this case 0)
    void DecreaseProgress()
    {
        statValue--;
        statValue = Mathf.Clamp(statValue, 0, int.MaxValue);
        UpdateProgressBar();
    }

    public void Reset()
    {
        statValue = 0;
        UpdateProgressBar();
    }
}
