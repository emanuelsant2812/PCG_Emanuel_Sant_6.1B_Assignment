using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public GameObject carprefab;

    // Start is called before the first frame update
    void Start()
    {
        int spawnPointX = Random.Range(-300, 300);
        int spawnPointZ = Random.Range(-300, 300);
        Vector3 spawnPoint = new Vector3(spawnPointX, 0, spawnPointZ);
        Instantiate(carprefab, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //instantiate Low Poly Car 1 Varaint prefab
    


}
