using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDragable : MonoBehaviour, IPointerClickHandler
{
    private Image spriteRenderer;

    public void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //spriteRenderer.sprite.name;

        if (spriteRenderer.sprite.name == "isometric_icon")//!Interface._obj.GetCameraMode_Ortho())
        {
            ModelObjectDragable(true);// Enable drag
            InteriorObjectDragable(true);

            /*ModelObjectDragable(true);
            InteriorObjectDragable(true);*/
        }
        else if (spriteRenderer.sprite.name == "prespective_icon")
        {
            ModelObjectDragable(false);// Dis-able drag
            InteriorObjectDragable(false);

            /*ModelObjectDragable(false);
            InteriorObjectDragable(false);*/
        }
    }

    public void ModelObjectDragable(bool state)
    {
        var modelList = InstantiatedGameObject._obj.GetInstantiatedModelObjList();
        foreach (GameObject_Model modelObj in modelList)
        {
            modelObj.GetGameObject().GetComponent<ObjectDrag>().enabled = state;
        }
    }

    public void InteriorObjectDragable(bool state)
    {
        var interiorList = InstantiatedGameObject._obj.GetInstantiatedInteriorObjList();
        foreach (GameObject_Interior interiorObj in interiorList)
        {
            interiorObj.GetGameObject().GetComponent<ObjectDrag>().enabled = state;
        }
    }

}
