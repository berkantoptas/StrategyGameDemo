using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPool : MonoBehaviour
{
    // the prefab that this object pool returns instances of
    public GameObject prefab;
    public GameObject gameManager;
    public GameObject barrackObject;
    public GameObject powerPlantObject;
    public Camera camera;

    public Transform buildings;

    public bool isBarrack=false;

    // Returns an instance of the prefab
    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);
           
        if(isBarrack==true)
        {
            spawnedGameObject.GetComponent<BarrackDraggable>().SetBarrackObject(barrackObject);
            spawnedGameObject.GetComponent<BarrackDraggable>().SetCamera(camera);
            spawnedGameObject.GetComponent<BarrackDraggable>().SetGameManager(gameManager.GetComponent<GameManager>());
            spawnedGameObject.GetComponent<BarrackDraggable>().SetBuildingsTransform(buildings);
        }
        else
        {
            spawnedGameObject.GetComponent<PowerPlantDraggable>().SetPowerPlantObject(powerPlantObject);
            spawnedGameObject.GetComponent<PowerPlantDraggable>().SetCamera(camera);
            spawnedGameObject.GetComponent<PowerPlantDraggable>().SetGameManager(gameManager.GetComponent<GameManager>());
            spawnedGameObject.GetComponent<PowerPlantDraggable>().SetBuildingsTransform(buildings);
        }

        // put the instance in the root of the scene and enable it
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        // return a reference to the instance
        return spawnedGameObject;
    }
    
}