using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 mOffset;
    private float mZCoord;

    public void OnPointerDown(PointerEventData eventData)
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = gameobject world pos = mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        Interface._obj.SetDragObj(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.gameObject.name.Contains("wall") || this.gameObject.name.Contains("window") || this.gameObject.name.Contains("door"))
            InstantiatedGameObject._obj.GetInstantiatedModelObj(this.gameObject).SetStartPos(this.gameObject.transform.position);
        else
            InstantiatedGameObject._obj.GetInstantiatedInteriorObj(this.gameObject).SetPosition(this.gameObject.transform.position);
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        //Pixel coord of mouse(x,y);
        Vector3 mousePoint = Input.mousePosition;

        //z coord of game object on screen
        mousePoint.z = mZCoord;

        //Convert to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    
}
