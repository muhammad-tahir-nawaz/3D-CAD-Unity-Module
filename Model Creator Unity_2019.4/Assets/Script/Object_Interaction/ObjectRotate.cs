using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool objTouched;

    // Update is called once per frame
    void Update()
    {

        if (Interface._obj.GetRotateObj() && objTouched)
        {
            this.gameObject.transform.eulerAngles += new Vector3(0, this.gameObject.transform.eulerAngles.y + 5, 0);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Interface._obj.GetRotateObj())
        {
            this.objTouched = true; 
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InstantiatedGameObject._obj.GetInstantiatedInteriorObj(this.gameObject).SetAngle(this.gameObject.transform.eulerAngles);
        
        this.objTouched = false;
    }
}
