using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Instantiate_UIElement_InteriorObj : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameObject uIElement;
    private GameObject uIPrefab;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        uIPrefab = (GameObject)Resources.Load("prefabs/UI_Elements/UIElment_Dynamic_InteriorObj", typeof(GameObject));
        canvas = Interface._obj.GetClassRefrence_UPV().GetCanvas();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Interface._obj.GetPanelRayCastDisable() && !Interface._obj.GetDragObj() && !Active_UIElements._obj.GetDynamicUIState() && !Interface._obj.GetPanelActive() && !Interface._obj.GetSelected_ModelObj() && !Interface._obj.GetSelected_InteriorObj())
        {
            Active_UIElements._obj.SetActiveElementParent(this.gameObject);

            Active_UIElements._obj.SetDynamicUIState(!Active_UIElements._obj.GetDynamicUIState());

            Active_UIElements._obj.SetModelObj(false);
            Active_UIElements._obj.SetInteriorObj(true);

            uIElement = Instantiate(uIPrefab) as GameObject;
            uIElement.transform.localPosition = Input.mousePosition;
            uIElement.transform.localScale = new Vector3(10, 10, 10);
            uIElement.transform.SetParent(canvas.transform);

            Active_UIElements._obj.SetActiveUIElement(uIElement);

            if (this.gameObject.name.Contains("Plant_"))
            {
                GameObject.Find("Object_Info_Button").SetActive(false);
            }


        }

        if (Interface._obj.GetDragObj())
        {
            Interface._obj.SetDragObj(false);
        }

        if (Interface._obj.GetPanelRayCastDisable())
        {
            Interface._obj.SetPanelRayCastDisable(false);
        }
    }


}
