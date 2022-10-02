using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationMinion : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        // Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public GameObject New(){
        return Instantiate(myPrefab, new Vector3(-200.6f, -3.1f, 0) + Vector3.up * Random.Range(-20,0), Quaternion.identity);
    }
}
