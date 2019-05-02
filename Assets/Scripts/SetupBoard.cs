using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBoard : MonoBehaviour {

    public GameObject parentObject;
    public Material redMat;

    public GameObject activeCell;

    float cellSize;

    // Use this for initialization
    void Start () {

        cellSize = 0.5668f;

        for (int i = 0; i < 16; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                GameObject cell = new GameObject("Grid" + i + "*" + j, typeof(MeshRenderer), typeof(MeshFilter), typeof(BoxCollider2D), typeof(Cell));

                Cell cellScript = cell.GetComponent<Cell>();               
                cellScript.boardScript = parentObject.transform.parent.GetComponent<SetupBoard>();
                cellScript.currentCell = cell;

                cell.transform.SetParent(parentObject.transform);
                cell.tag = "Board";

                BoxCollider2D bc = cell.GetComponent<BoxCollider2D>();

                bc.size = new Vector2(cellSize, cellSize);

                cell.transform.position = new Vector3(-4.250f + i * cellSize, -4.250f + j * cellSize, 0);

                Mesh mesh = new Mesh();
            
                Vector3[] vertices = new Vector3[4];
                vertices[0] = new Vector3(-cellSize/2, -cellSize/2, 0);
                vertices[1] = new Vector3(-cellSize/2, cellSize/2, 0);
                vertices[2] = new Vector3(cellSize/2, cellSize/2, 0);
                vertices[3] = new Vector3(cellSize/2, -cellSize/2, 0);

                int[] triangles = new int[] { 0, 1, 2, 2, 3, 0 };

                mesh.vertices = vertices;
                mesh.triangles = triangles;

                MeshFilter mf = cell.GetComponent<MeshFilter>();
                mf.mesh = mesh;

                MeshRenderer mr = cell.GetComponent<MeshRenderer>();
                mr.material = redMat;
                mr.enabled = false;      
            }
        }
    }

    public Vector3 GetClosestCellPosition(Vector3 mousePosition, string itemTag)
    {
        int i = (int)((mousePosition.y + 4.250f) / cellSize);
        int j = (int)((mousePosition.x + 4.250f) / cellSize);

        if(itemTag=="BarrackObject")
        {
            if (i < 1)
                i = 1;
            if (i > 13)
                i = 13;
            if (j < 2)
                j = 2;
            if (j > 14)
                j = 14;
        }
        if(itemTag=="PowerPlantObject")
        {
            if (i < 0)
                i = 0;
            if (i > 14)
                i = 14;
            if (j < 1)
                j = 1;
            if (j > 14)
                j = 14;
        }

        float posY = -4.250f + i * cellSize;
        float posX = -4.250f + j * cellSize;

        return new Vector3(posX,posY,0);
    }
}
