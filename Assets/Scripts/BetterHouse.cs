using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterHouse : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 floorSize = new Vector3(100f, 0.4f, 100f);
    [SerializeField]
    private Vector3 roofSize = new Vector3(100f, 0.400000006f, 105f);
    [SerializeField]
    private Vector3 sideWallSize = new Vector3(100f, 100f, 5f);
    [SerializeField]
    private Vector3 frontBackWallSize = new Vector3(5f, 100f, 100f);
    [SerializeField]
    private Vector3 mainDoorSize = new Vector3(5f, 40f, 40f);
    [SerializeField]
    private Vector3 frontWindowSize = new Vector3(5f, 25f, 25f);
    [SerializeField]
    private Vector3 sideWindowSize = new Vector3(35f, 35f, 5f);
    [SerializeField]
    private Vector3 floorPosition = new Vector3(0f, 0.8f, 0f);
    [SerializeField]
    private Vector3 roofPosition = new Vector3(0f, 202f, 0.300003052f);
    [SerializeField]
    private Vector3 leftWallPosition = new Vector3(0f, 101.199997f, 100.300003f);
    [SerializeField]
    private Vector3 rightWallPosition = new Vector3(0f, 101.199997f, -99.6999969f);
    [SerializeField]
    private Vector3 frontWallPosition = new Vector3(-95f, 101.199997f, 5.30000305f);
    [SerializeField]
    private Vector3 backWallPosition = new Vector3(95f, 101.199997f, 0f);
    [SerializeField]
    private Vector3 mainDoorPosition = new Vector3(-96f, 40f, 1f);
    [SerializeField]
    private Vector3 leftFrontWindowPosition = new Vector3(-96f, 145f, 50f);
    [SerializeField]
    private Vector3 rightFrontWindowPosition = new Vector3(-96f, 145f, -49f);

    [SerializeField]
    private Vector3 leftWindowPosition = new Vector3(7f, 139f, 101f);
    [SerializeField]
    private Vector3 rightWindowPosition = new Vector3(0f, 139f, -100f);

    GameObject houseGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //CreateHouse();
        for (int i = 0; i < 5; i++)
        {

            //Vector3 randomPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            //GameObject newHouse = Instantiate(houseGameObject, randomPosition, Quaternion.identity);
            //newHouse.transform.parent = this.transform;
            CreateHouse();

        }
    }

    private void InitializeHouse()
    {
        houseGameObject = new GameObject();
        houseGameObject.name = "House";
        houseGameObject.transform.position = this.transform.position;
        houseGameObject.transform.rotation = this.transform.rotation;
        houseGameObject.transform.localScale = this.transform.localScale;
        houseGameObject.transform.parent = this.transform;
    }




    private void CreateHouse()
    {
        int spawnPointX = Random.Range(-3000, 3000);
        int spawnPointY = 0;
        int spawnPointZ = Random.Range(-3000, 3000);
        Vector3 spawnPoint = new Vector3(spawnPointX, 0, spawnPointZ);
        InitializeHouse();
        // Floor
        CreateFloor(floorSize, "Floor", floorPosition + spawnPoint, FloorMaterialList());
        // Roof
        CreateRoof(roofSize, "Roof", roofPosition + spawnPoint, RoofMaterialList());
        //Left Wall
        CreateWall(sideWallSize, "Left Wall", leftWallPosition + spawnPoint, SideWallMaterialList());
        //Right Wall
        CreateWall(sideWallSize, "Right Wall", rightWallPosition + spawnPoint, SideWallMaterialList());
        //Front Wall
        CreateWall(frontBackWallSize, "Front Wall", frontWallPosition + spawnPoint, FrontBackWallMaterialList());
        //Back Wall
        CreateWall(frontBackWallSize, "Back Wall", backWallPosition + spawnPoint, FrontBackWallMaterialList());
        //Door
        CreateAperture(mainDoorSize, "Main Door", mainDoorPosition + spawnPoint, MainDoorMaterialList());
        //Left front Window
        CreateAperture(frontWindowSize, "Left Front Window", leftFrontWindowPosition + spawnPoint, WindowMaterialList());
        //Right front Window
        CreateAperture(frontWindowSize, "Right Front    Window", rightFrontWindowPosition + spawnPoint, WindowMaterialList());
        //Left Side Window
        CreateAperture(sideWindowSize, "Left Side Window", leftWindowPosition + spawnPoint, WindowMaterialList());
        //Right Side Window
        CreateAperture(sideWindowSize, "Right Side Window", rightWindowPosition + spawnPoint, WindowMaterialList());

    }

    private void CreateFloor(Vector3 floorSize, string name, Vector3 floorPosition,
                            List<Material> FloorMaterialList)
    {
        GameObject cube = new GameObject();
        cube.name = name;
        Cube cubeScript = cube.AddComponent<Cube>();
        cubeScript.UpdateSubmeshCount(1);
        cubeScript.UpdateSubmeshIndex(0, 0, 0, 0, 0, 0);
        cubeScript.UpdateCubeMaterialsList(FloorMaterialList);
        cube.transform.rotation = this.transform.rotation;
        cube.transform.localScale = floorSize;
        cube.transform.position = floorPosition;
        cube.transform.parent = houseGameObject.transform;
    }

    

    private void CreateRoof(Vector3 roofSize, string name, Vector3 roofPosition,
                            List<Material> RoofMaterialList)
    {
        GameObject cube = new GameObject();
        cube.name = name;
        Cube cubeScript = cube.AddComponent<Cube>();
        cubeScript.UpdateSubmeshCount(1);
        cubeScript.UpdateSubmeshIndex(0, 0, 0, 0, 0, 0);
        cubeScript.UpdateCubeMaterialsList(RoofMaterialList);
        cube.transform.rotation = this.transform.rotation;
        cube.transform.localScale = roofSize;
        cube.transform.position = roofPosition;
        cube.transform.parent = houseGameObject.transform;
    }


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
        cube.transform.parent = houseGameObject.transform;
    }

    private void CreateAperture(Vector3 apertureSize, string name, Vector3 position,
                            List<Material> apertureMaterialList)
    {
        GameObject cube = new GameObject();
        cube.name = name;
        Cube cubeScript = cube.AddComponent<Cube>();
        cubeScript.UpdateSubmeshCount(1);
        cubeScript.UpdateSubmeshIndex(0, 0, 0, 0, 0, 0);
        cubeScript.UpdateCubeMaterialsList(apertureMaterialList);
        cube.transform.rotation = this.transform.rotation;
        cube.transform.localScale = apertureSize;
        cube.transform.position = position;
        cube.transform.parent = houseGameObject.transform;
    }

   

    private List<Material> FrontBackWallMaterialList()
    {
        List<Material> frontBackWallMaterialList = new List<Material>();

        Material whiteMaterial = new Material(Shader.Find("Specular"));
        whiteMaterial.color = Color.white;

        frontBackWallMaterialList.Add(whiteMaterial);

        return frontBackWallMaterialList;
    }

    private List<Material> SideWallMaterialList()
    {
        List<Material> sideWallMaterialList = new List<Material>();

        Material yellowMaterial = new Material(Shader.Find("Specular"));
        yellowMaterial.color = Color.yellow;

        sideWallMaterialList.Add(yellowMaterial);

        return sideWallMaterialList;
    }

    private List<Material> FloorMaterialList()
    {
        List<Material> floorMaterialList = new List<Material>();

        Material blackMaterial = new Material(Shader.Find("Specular"));
        blackMaterial.color = Color.black;

        floorMaterialList.Add(blackMaterial);

        return floorMaterialList;
    }

    private List<Material> RoofMaterialList()
    {
        List<Material> roofMaterialList = new List<Material>();

        Material magentaMaterial = new Material(Shader.Find("Specular"));
        magentaMaterial.color = Color.magenta;

        roofMaterialList.Add(magentaMaterial);

        return roofMaterialList;
    }

    private List<Material> MainDoorMaterialList()
    {
        List<Material> mainDoorMaterialList = new List<Material>();

        Material redMaterial = new Material(Shader.Find("Specular"));
        redMaterial.color = Color.red;

        mainDoorMaterialList.Add(redMaterial);

        return mainDoorMaterialList;
    }

    private List<Material> WindowMaterialList()
    {
        List<Material> windowMaterialList = new List<Material>();

        Material grayMaterial = new Material(Shader.Find("Specular"));
        grayMaterial.color = Color.gray;

        windowMaterialList.Add(grayMaterial);

        return windowMaterialList;
    }


}
