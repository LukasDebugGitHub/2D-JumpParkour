using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SawbaldeChains : MonoBehaviour
{
    public GameObject chainPrefab;
    public Vector2 startPos;
    public Vector2 endPos;
    public float distanceBetweenObjectsX;
    public float distanceBetweenObjectsY;
    public int chainCount;

    private Vector2 prefabPosition;

    public List<GameObject> instantiatedChainPref = new List<GameObject>();

    int value;

    bool prefabsInstantiated = false;

    private void Start()
    {
        prefabPosition = transform.position;
    }

    private void OnDrawGizmos()
    {
        if(chainPrefab == null)
        {
            return;
        }

        if (prefabsInstantiated)
        {
            RemoveExcessPrefabs(chainCount);
        }

        if (value < chainCount)
        {
            GameObject newPref = Instantiate(chainPrefab, prefabPosition, transform.rotation);
            instantiatedChainPref.Add(newPref);

            prefabPosition += new Vector2(distanceBetweenObjectsX, distanceBetweenObjectsY);

            value++;
        }
        else if (chainCount == 0)
        {
            prefabPosition = transform.position;
            value = 0;
        }

        prefabsInstantiated = true;
    }

    private void RemoveExcessPrefabs(int numberOfPrefabs)
    {
        // Entferne die überschüssigen Prefabs
        int excessPrefabs = instantiatedChainPref.Count - numberOfPrefabs;
        if (excessPrefabs > 0)
        {
            // Lösche überschüssige Prefabs
            for (int i = 0; i < excessPrefabs; i++)
            {
                DestroyImmediate(instantiatedChainPref[instantiatedChainPref.Count - 1]); // Lösche das letzte Prefab
                instantiatedChainPref.RemoveAt(instantiatedChainPref.Count - 1); // Entferne es aus der Liste
            }
        }
    }
}
