using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class Cube : MonoBehaviour
{

    [SerializeField]
    private Vector3 size = Vector3.one;

    [SerializeField]
    private int submeshCount = 6;

    [SerializeField]
    private int topSquareSubmesh    = 0;
    [SerializeField]
    private int bottomSquareSubmesh = 1;
    [SerializeField]
    private int frontSquareSubmesh  = 2;
    [SerializeField]
    private int backSquareSubmesh   = 3;
    [SerializeField]
    private int leftSquareSubmesh   = 4;
    [SerializeField]
    private int rightSquareSubmesh  = 5;

    private List<Material> cubeMaterialsList = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        CreateCube();
    }
    
    public void UpdateSubmeshCount(int submeshCount){
        this.submeshCount = submeshCount;
    }

    public void UpdateSubmeshIndex(int top, int bottom, int front,
                                   int back, int left, int right){
        this.frontSquareSubmesh = front;
        this.bottomSquareSubmesh = bottom;
        this.topSquareSubmesh = top;
        this.backSquareSubmesh = back;
        this.leftSquareSubmesh = left;
        this.rightSquareSubmesh = right;
    }

    public void UpdateCubeMaterialsList(List<Material> cubeMaterialsList){
        this.cubeMaterialsList = cubeMaterialsList;
    }

    private void CreateCube(){
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();

        MeshBuilder meshBuilder = new MeshBuilder(submeshCount);

        MeshCollider meshCollider = this.GetComponent<MeshCollider>();


        //declare vertices
        Vector3 t0 = new Vector3(size.x, size.y, -size.z);
        Vector3 t1 = new Vector3(-size.x, size.y, -size.z);
        Vector3 t2 = new Vector3(-size.x, size.y, size.z);
        Vector3 t3 = new Vector3(size.x, size.y, size.z);

        Vector3 b0 = new Vector3(size.x, -size.y, -size.z);
        Vector3 b1 = new Vector3(-size.x, -size.y, -size.z);
        Vector3 b2 = new Vector3(-size.x, -size.y, size.z);
        Vector3 b3 = new Vector3(size.x, -size.y, size.z);


        //declare triangles

        //top square
        meshBuilder.BuildTriangle(t0,t1,t2,topSquareSubmesh);
        meshBuilder.BuildTriangle(t0,t2,t3,topSquareSubmesh);

        //bottom square
        meshBuilder.BuildTriangle(b2,b1,b0,bottomSquareSubmesh);
        meshBuilder.BuildTriangle(b3,b2,b0,bottomSquareSubmesh);

        //front square
        meshBuilder.BuildTriangle(b2,t3,t2,frontSquareSubmesh);
        meshBuilder.BuildTriangle(b2,b3,t3,frontSquareSubmesh);

        //back square
        meshBuilder.BuildTriangle(b0,t1,t0,backSquareSubmesh);
        meshBuilder.BuildTriangle(b0,b1,t1,backSquareSubmesh);


        //left square
        meshBuilder.BuildTriangle(b1,t2,t1,leftSquareSubmesh);
        meshBuilder.BuildTriangle(b1,b2,t2,leftSquareSubmesh);

        //right square
        meshBuilder.BuildTriangle(b3,t0,t3,rightSquareSubmesh);
        meshBuilder.BuildTriangle(b3,b0,t0,rightSquareSubmesh);

        meshFilter.mesh = meshBuilder.CreateMesh();

        MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();        

        if(cubeMaterialsList.Count <= 0){
            CubeMaterials cubeMaterials = new CubeMaterials();
            cubeMaterialsList = cubeMaterials.GetCubeMaterialsList();
        }

        meshRenderer.materials = cubeMaterialsList.ToArray();

        meshCollider.sharedMesh = meshFilter.mesh;
    }

}
