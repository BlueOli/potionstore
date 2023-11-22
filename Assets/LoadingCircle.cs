using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoadingCircle : MonoBehaviour
{
    public Transform loadingBar;
    public Transform textIndicator;
    public Transform loadingText;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    public float CurrentAmount { get => currentAmount; set => currentAmount = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmount< 100)
        {
            
            textIndicator.GetComponent<TextMeshProUGUI>().text = ((int)currentAmount).ToString() + "%";
            loadingText.gameObject.SetActive(true);
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            textIndicator.GetComponent<TextMeshProUGUI>().text = "Done";
        }   
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
