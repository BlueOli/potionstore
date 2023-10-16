using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class PlantPManagerEditorWindow : EditorWindow
{
    private PlantPManager plantManager;
    private PlantPManager mushroomManager;
    [MenuItem("Window/Plant Manager Editor")]
    public static void ShowWindow()
    {
        GetWindow<PlantPManagerEditorWindow>("Plant Manager Editor");
    }

    private void OnEnable()
    {
        GameObject plantHolder = GameObject.Find("PlantHolder");
        GameObject mushroomHolder = GameObject.Find("MushroomHolder");
        plantManager = plantHolder.GetComponentInChildren<PlantPManager>();
        mushroomManager = mushroomHolder.GetComponentInChildren<PlantPManager>();
    }

    private void OnGUI()
    {
        
        if (plantManager == null)
        {
            EditorGUILayout.LabelField(plantManager.gameObject.name + "Plant Manager not found in the scene.");
            return;
        }
        if (mushroomManager == null)
        {
            EditorGUILayout.LabelField(mushroomManager.gameObject.name + "Mushroom Manager not found in the scene.");
            return;
        }

        Dictionary<string, int> plantQuantities = plantManager.PlantQuantities;
        Dictionary<string, int> mushQuantities = mushroomManager.PlantQuantities;

        GUILayout.Label("Comienzo del diccionario de plantas");
        if (plantQuantities == null || plantQuantities.Count <1)
        {
            EditorGUILayout.LabelField("Plant Quantities is less than 1.");
            return;
        }
        EditorGUILayout.LabelField("Diccionario A" + plantQuantities);
        foreach (string plantName in plantQuantities.Keys)
        {
            int quantity = plantQuantities[plantName];
            GUILayout.Label("Plant Name: " + plantName + ", Quantity: " + quantity.ToString());
        }
        GUILayout.Label("Fin del diccionario");

        GUILayout.Label("Comienzo del diccionario de hongos");
        if (mushQuantities == null || mushQuantities.Count < 1)
        {
            EditorGUILayout.LabelField("Mushroom Quantities is less than 1.");
            return;
        }
        EditorGUILayout.LabelField("Diccionario A" + mushQuantities);
        foreach (string plantName in mushQuantities.Keys)
        {
            int quantity = mushQuantities[plantName];
            GUILayout.Label("Plant Name: " + plantName + ", Quantity: " + quantity.ToString());
        }
        GUILayout.Label("Fin del diccionario");

    }
}

