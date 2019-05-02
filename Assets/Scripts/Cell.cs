using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public GameObject currentCell;
    public SetupBoard boardScript;

    public void OnMouseDown()
    {
        if(boardScript.activeCell==null)
        {
            currentCell.GetComponent<MeshRenderer>().enabled = true;
            boardScript.activeCell = currentCell;
        }
        else
        {
            boardScript.activeCell.GetComponent<MeshRenderer>().enabled = false;
            currentCell.GetComponent<MeshRenderer>().enabled = true;
            boardScript.activeCell = currentCell;
        }
    }
}
