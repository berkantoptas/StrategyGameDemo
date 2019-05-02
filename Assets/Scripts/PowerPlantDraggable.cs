using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PowerPlantDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;

    private GameObject powerPlantObject;

    private Camera camera;
    private GameManager gameManager;

    private Transform buildings;

    private GameObject newBuilding;

    public void SetPowerPlantObject(GameObject go)
    {
        powerPlantObject = go;
    }

    public void SetCamera(Camera cam)
    {
        camera = cam;
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void SetBuildingsTransform(Transform b)
    {
        buildings = b;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;

        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        newBuilding = Instantiate(powerPlantObject);

        //Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        newBuilding.transform.position = camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, camera.nearClipPlane));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 alignPos = gameManager.sb.GetClosestCellPosition(camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, camera.nearClipPlane)), newBuilding.tag);
        //alignPos.x -= 0.1889f;
        alignPos.y += 0.2834f;

        newBuilding.transform.position = alignPos; //camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, camera.nearClipPlane));
        newBuilding.GetComponent<PowerPlant>().SetGameManager(gameManager);
        newBuilding.transform.SetParent(buildings);

        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        //Debug.Log("OnEndDrag");
    }
}
