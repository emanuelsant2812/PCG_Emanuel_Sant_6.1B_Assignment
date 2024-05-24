using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2 : MonoBehaviour
{
    private Vector3 exitSize = new Vector3(100f, 100f, 100f);
    [SerializeField]

    void Start()
    {
        int spawnPointX = Random.Range(-3000, 3000);
        int spawnPointZ = Random.Range(-3000, 3000);
        Vector3 spawnPoint = new Vector3(spawnPointX, 0, spawnPointZ);
        CreateWall(exitSize, "Exit", spawnPoint, exitMaterialList());
    }

    //when the car frefabhits the exit, the scene changes
    private void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            SceneManager.LoadScene("Terrain");
        }
    }

    GameObject exitGameObject;

    private void CreateWall(Vector3 wallSize, string name, Vector3 position,
                        List<Material> wallMaterialList)
    {
        GameObject cube = new GameObject();
        cube.name = name;
        Cube cubeScript = cube.AddComponent<Cube>();
        cubeScript.UpdateSubmeshCount(1);
        cubeScript.UpdateSubmeshIndex(0, 0, 0, 0, 0, 0);
        cubeScript.UpdateCubeMaterialsList(wallMaterialList);
        cube.transform.rotation = this.transform.rotation;
        cube.transform.localScale = wallSize;
        cube.transform.position = position;
        cube.transform.parent = exitGameObject.transform;
        exitGameObject.AddComponent<SceneChanger2>();
    }

    private List<Material> exitMaterialList()
    {
        List<Material> exitMaterialList = new List<Material>();

        Material blueMaterial = new Material(Shader.Find("Specular"));
        blueMaterial.color = Color.red;

        exitMaterialList.Add(blueMaterial);

        return exitMaterialList;
    }
}
