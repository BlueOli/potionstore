using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AddCropTypes : MonoBehaviour
{
    string cropType = null; // Crop type: "Mushroom" or "Plant"

    private bool imagesCreated = false;

    public PlantType plantType = null;

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
                    SelectCropType selectedCropTypeScript = imageObject.AddComponent<SelectCropType>();
                    plantType = CreatePlantType(imageObject.name, imageObject.GetComponent<Image>().sprite, cropType);
                    selectedCropTypeScript.MyPlantType = plantType;
                    
                }
                else
                {
                    Debug.LogError("Sprite not found: " + image.name);
                }
            }

            imagesCreated = true;
        }
    }

    private PlantType CreatePlantType(string plantName, Sprite img, string cropType)
    {
        // Create a new PlantType object
        PlantType plantType = new PlantType();
        plantType.plantName = plantName;
        plantType.plantIcon = img; 
        plantType.growTime = SelectGrowTime(plantName, cropType);
          
        return plantType;
    }

    /// <summary>   
    /// Esta funcion actua como ajuste de balance de los tiempos de crecimiento de las plantas. Los valores a utilizar son 8-10-12-15-20
    /// </summary>
    private float SelectGrowTime(string plantName, string cropType)
    {
        if (cropType == "Mushroom")
        {
            switch (plantName)
            {
                case "BowRoom":
                    return 20f;
                case "GlowRoom":
                    return 12f;
                case "NormalRoom":
                    return 8f;
                case "RedRoom":
                    return 8f;
                case "SwampRoom":
                    return 12f;
                case "ToxicRoom":
                    return 15f;
                default:
                    break;
            }

        }
        else if (cropType == "Plant")
        {
            switch (plantName)
            {
                case "Mandragora":
                    return 20f;
                case "SpikeGlobe":
                    return 12f;
                case "Acorn":
                    return 8f;
                case "HardRoot":
                    return 8f;
                case "FrozenRoot":
                    return 12f;
                case "GoldLeaf":
                    return 15f;
                default:
                    break;
            }
        }
        return 0f;
    }

}
