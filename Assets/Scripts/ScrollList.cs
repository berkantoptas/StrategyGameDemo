using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollList : MonoBehaviour {

    public int itemNumber;
    public Transform contentPanel;
    public ObjectPool itemObjectPool;
    public Sprite itemIcon;


    // Use this for initialization
    void Start ()
    {
        AddItems();
    }

    private void AddItems()
    {
        for (int i = 0; i < itemNumber; i++)
        {
            GameObject newItem = itemObjectPool.GetObject();
            newItem.transform.SetParent(contentPanel);
            newItem.GetComponent<Image>().sprite = itemIcon;
        }
    }

}
