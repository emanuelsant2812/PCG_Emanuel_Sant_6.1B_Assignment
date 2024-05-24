using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSpwaner : MonoBehaviour
{
    public GameObject seaprefab;

    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 spawnPoint = new Vector3(0, 170, 0);
        Instantiate(seaprefab, spawnPoint, Quaternion.identity);
    }
}
