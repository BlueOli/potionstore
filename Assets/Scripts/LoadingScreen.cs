using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour // Este script se encuentra en el objeto EventSystem
{
    public Slider progressSlider; 
    public float loadingDuration = 8f; 

    private float loadingTimer = 0f; 

    private void Start()
    {
        StartLoading();
    }

    private void Update()
    {
        loadingTimer += Time.deltaTime;

        float progress = loadingTimer / loadingDuration;
        progressSlider.value = progress;

        if (loadingTimer >= loadingDuration) {FinishLoading();}
    }

    private void StartLoading()
    {
        loadingTimer = 0f;
        progressSlider.value = 0f;       
    }

    ///<summary>
    /// Esta funcion es llamada cuando termina de cargar la escena.
    ///</summary>
    private void FinishLoading()
    {        
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneBuildIndex = currentScene.buildIndex + 1;
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
