using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject BInfo, PPInfo, SInfo;

    public GameObject SItem;
    public Transform soldiers;
    public Transform buildings;

    public SetupBoard sb;

    public GameObject activeSoldier;

    public GameObject productionMenu;
    public GameObject blackFade;

    private int soldierID;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeOut());
        productionMenu.SetActive(false);
        productionMenu.SetActive(true);
        soldierID = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        blackFade.SetActive(false);
    }

    public void ProduceSoldier()
    {
        GameObject newSItem = Instantiate(SItem, soldiers.position, soldiers.rotation);
        newSItem.name = "Soldier" + soldierID.ToString();

        newSItem.transform.position = sb.activeCell.transform.position;

        soldierID++;
        newSItem.transform.SetParent(soldiers.transform);
        newSItem.GetComponent<Soldier>().SetGameManager(this);
        newSItem.GetComponent<Soldier>().SetSoldierObject(newSItem);
    }
}
