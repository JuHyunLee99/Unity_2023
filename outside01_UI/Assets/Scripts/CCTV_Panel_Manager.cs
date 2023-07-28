using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CCTV_Panel_Manager : MonoBehaviour
{
    private static CCTV_Panel_Manager _instance;
    public static CCTV_Panel_Manager Instance => _instance;

    private Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();

    private string cctvURL = "";

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
    }

    public void AddPrefabForButton(string mapPinName, GameObject prefab)
    {
        if(!prefabDictionary.ContainsKey(mapPinName))
        {
            prefabDictionary.Add(mapPinName, prefab);
        }
        else
        {
            prefabDictionary[mapPinName] = prefab;
        }
    }

    public void SpawnPrefabInUIScene(string mapPinName, string cctvurl) 
    {
        cctvURL = cctvurl;
        if (prefabDictionary.TryGetValue(mapPinName, out GameObject prefabToSpaw))
        {
            UIPrefabSpawner uIPrefabSpawner = FindObjectOfType<UIPrefabSpawner>();
            if (uIPrefabSpawner != null)
            {
                uIPrefabSpawner.SpawnPrefab(prefabToSpaw, cctvURL);
            }
            else
            {
                Debug.LogError("UIPrefabSpawner not found in the scene.");
            }
        } 
    }

    public string GetCCTVURL()
    {
        return cctvURL;
    }
}
