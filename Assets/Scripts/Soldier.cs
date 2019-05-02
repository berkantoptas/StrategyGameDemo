using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject soldierObject;

    public void SetSoldierObject(GameObject go)
    {
        soldierObject = go;
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void OnMouseDown()
    {
        if (gameManager.activeSoldier != null)
        {
            SpriteRenderer sr = gameManager.activeSoldier.GetComponent<SpriteRenderer>();
            Color color = new Color(1.0f, 1.0f, 1.0f);
            sr.color = color;
        }

        SpriteRenderer sr2 = soldierObject.GetComponent<SpriteRenderer>();
        Color color2 = new Color(0.3f, 1.0f, 0.2f);
        sr2.color = color2;

        gameManager.activeSoldier = soldierObject;
        
        gameManager.BInfo.SetActive(false);
        gameManager.PPInfo.SetActive(false);
        gameManager.SInfo.SetActive(true);
    }
}
