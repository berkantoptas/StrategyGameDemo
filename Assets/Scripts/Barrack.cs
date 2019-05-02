using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : MonoBehaviour {

    private GameManager gameManager;

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void OnMouseDown()
    {
        //Debug.Log("barrack");

        gameManager.BInfo.SetActive(true);
        gameManager.PPInfo.SetActive(false);
        gameManager.SInfo.SetActive(false);

        if (gameManager.activeSoldier != null)
        {
            SpriteRenderer sr = gameManager.activeSoldier.GetComponent<SpriteRenderer>();
            Color color = new Color(1.0f, 1.0f, 1.0f);
            sr.color = color;
            gameManager.activeSoldier = null;
        }
    }
}
