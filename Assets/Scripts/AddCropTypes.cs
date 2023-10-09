using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AddCropTypes : MonoBehaviour
{
    string cropType = null; // Crop type: "Mushroom" or "Plant"

    private bool imagesCreated = false;

    private void Start()
    {
        cropType = transform.parent.GetComponent<CropType>().type.ToString();
    }

    void Update()
    {
        if (cropType == null)
        {
            Debug.LogError("Crop type not set for " + gameObject.name);
            return;
        }

        // Check if the parent GameObject is activated and images are not already created
        if (gameObject.activeSelf && !imagesCreated)
        {
            // Get all sprites in the specified folder
            Sprite[] sprites = Resources.LoadAll<Sprite>("PlantsToUse/" + cropType );


            // Iterate through the sprite
            foreach (Sprite image in sprites)
            {
                
                if (image != null)
                {
                    
                    GameObject imageObject = new GameObject(image.name); // Create a new GameObject for the Image component
                    imageObject.transform.SetParent(transform); // Set the parent to the object this script is attached to

                    Image imageComponent = imageObject.AddComponent<Image>();
                    imageComponent.sprite = image; //Set the image on the sprite atribute in the component

                    Button buttonComponent = imageObject.AddComponent<Button>();

                    // TODO Agregar el script que se encarga de setear el tipo de cultivo seleccionado
                    //SelectedCropType selectedCropTypeScript = imageObject.AddComponent<SelectedCropType>();
                    // selectedCropTypeScript.SetSomeProperty(someValue);
                }
                else
                {
                    Debug.LogError("Sprite not found: " + image.name);
                }
            }

            imagesCreated = true;
        }
    }
}
