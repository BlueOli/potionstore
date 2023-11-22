using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchInputHandler : MonoBehaviour
{
    private bool isSliding = false;
    private float totalElapsedTime = 0f; // Total elapsed time across multiple touches
    private float slideDuration = 2f; // Duration for sliding gesture in seconds
    private float slideProgress = 0f; // Current progress of the sliding gesture
    private bool mixedReady = false; // Flag indicating if the gesture is complete

    public Image filledBar; // Reference to the filled bar image
    public TextMeshProUGUI progressText; // Reference to the text displaying progress
    public PotionMaker potionMaker;
    public LoadingCircle loadingCircle;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && potionMaker.isMixed)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Start sliding when the finger is first touched
                isSliding = true;
            }
            else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && isSliding)
            {
                // Continue sliding as long as the finger is on the screen
                totalElapsedTime += Time.deltaTime;
                slideProgress = Mathf.Clamp01(totalElapsedTime / slideDuration);
                loadingCircle.CurrentAmount = slideProgress * 100;
                // Update progress bar
                filledBar.fillAmount = slideProgress;

                // Update progress text
                //progressText.text = $"{Mathf.RoundToInt(slideProgress * 100)}%";

                // Check if sliding duration is completed
                if (totalElapsedTime >= slideDuration)
                {
                    mixedReady = true;
                    isSliding = false;
                    Debug.Log("Sliding gesture completed!");
                    potionMaker.isMixingDone = true;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Stop sliding when the finger is lifted
                isSliding = false;
            }
        }
    }

    public void ResetVariables()
    {
        // Reset all variables
        isSliding = false;
        totalElapsedTime = 0f;
        slideProgress = 0f;
        mixedReady = false;
        filledBar.fillAmount = 0f;
        //progressText.text = "0%";
    }
    

    public bool MixedReady
    {
        get { return mixedReady; }
    }
}

