using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteriorObjInfo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Interface._obj.GetObjInfoPanelState())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RayCasts rayCasts = new RayCasts();
                
                if (!rayCasts.GraphicRaycast("Object_Info", GetComponent<EventSystem>()))
                {
                    Interface._obj.GetClassRefrence_UPV().GetObjectInfo().SetActive(false);
                    Interface._obj.SetObjInfoPanelState(false);
                }
            }
        }
    }

}
