using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPrefabSpawner : MonoBehaviour
{
    public Text urlText;

    public void SpawnPrefab(GameObject prefabToSpawn, string cctvurl)
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // ¸ô¶ó....
        //if (newPrefab.TryGetComponent<SomeScriptThatRequiresCCTVURL>(out SomeScriptThatRequiresCCTVURL script))
        //{
        //    script.SetCCTVURL(cctvurl);
        //}

        // Update the URL text in the prefab (if you have a Text component to display the URL)
        if (urlText != null)
        {
            urlText.text = cctvurl;
        }
    }
}
