using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPin : MonoBehaviour
{
    public string mapPinName;
    public string cctvURL;

    public void OnClick()
    {
        // Find the UIPrefabSpawner in ui_scene
        UIPrefabSpawner uiPrefabSpawner = FindObjectOfType<UIPrefabSpawner>();

        if (CCTV_Panel_Manager.Instance != null)
        {
            CCTV_Panel_Manager.Instance.SpawnPrefabInUIScene(mapPinName, cctvURL);
            Debug.Log("MapPin is clicked");
        }
    }
}
