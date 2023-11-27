using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public Image activeImage; // Image to display when sound is active
    public Image mutedImage; // Image to display when sound is muted

    private bool isMuted = false; // Flag to track sound state

    private void Start()
    {
        SetSoundState(!isMuted); // Set the initial sound state
    }

    public void ToggleSound()
    {
        isMuted = !isMuted; // Toggle the sound state
        SetSoundState(!isMuted); // Set the appropriate image based on the sound state

        if (isMuted)
        {
            AudioListener.volume = 0f; // Mute audio by setting volume to 0
        }
        else
        {
            AudioListener.volume = 1f; // Unmute audio by setting volume to 1
        }
    }

    private void SetSoundState(bool isActive)
    {
        activeImage.gameObject.SetActive(isActive); // Show/hide the active image
        mutedImage.gameObject.SetActive(!isActive); // Show/hide the muted image
    }
}
