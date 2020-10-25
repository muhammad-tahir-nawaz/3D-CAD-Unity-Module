using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object_InfoPanel : MonoBehaviour, IPointerClickHandler
{
    private TMPro.TextMeshProUGUI lengthGameObject;
    private TMPro.TextMeshProUGUI widthGameObject;
    private TMPro.TextMeshProUGUI heigthGameObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Interface._obj.GetObjInfoPanelState())
        {
            Interface._obj.GetClassRefrence_UPV().GetObjectInfo().SetActive(false);
            Interface._obj.SetObjInfoPanelState(false);
        }
        else
        {
            lengthGameObject = Interface._obj.GetClassRefrence_UPV().GetIOInteriorObjLength();
            widthGameObject = Interface._obj.GetClassRefrence_UPV().GetIOInteriorObjWidth();
            heigthGameObject = Interface._obj.GetClassRefrence_UPV().GetIOInteriorObjHeight();


            Interface._obj.GetClassRefrence_UPV().GetObjectInfo().SetActive(true);
            Interface._obj.SetObjInfoPanelState(true);

            var name = Active_UIElements._obj.GetActiveElementParent().name;
            if (name.Contains("wall") || name.Contains("door") || name.Contains("window"))
            {
                GetModelObjData(Active_UIElements._obj.GetActiveElementParent());
            }
            else
            {
                GetInteriorObjData(name);
            }
        }
        //Interface._obj.SetObjInfoPanelActive(true);
    }

    private void GetInteriorObjData(string objName)
    {
        switch (objName)
        {
            case "Bed_1(Clone)":
                lengthGameObject.text = "1.30 m";
                widthGameObject.text = "0.30 m";
                heigthGameObject.text = "0.80 m";
                break;
            case "Bed_2(Clone)":
                lengthGameObject.text = "1.60 m";
                widthGameObject.text = "0.30 m";
                heigthGameObject.text = "0.90 m";
                break;
            case "Bed_3(Clone)":
                lengthGameObject.text = "1.60 m";
                widthGameObject.text = "0.60 m";
                heigthGameObject.text = "0.60 m";
                break;
            case "Chair_1(Clone)":
                lengthGameObject.text = "1.30 m";
                widthGameObject.text = "0.30 m";
                heigthGameObject.text = "0.80 m";
                break;
            case "Chair_2(Clone)":
                lengthGameObject.text = "1.60 m";
                widthGameObject.text = "0.30 m";
                heigthGameObject.text = "0.90 m";
                break;
            case "Chair_3(Clone)":
                lengthGameObject.text = "1.60 m";
                widthGameObject.text = "0.60 m";
                heigthGameObject.text = "0.60 m";
                break;
            case "Sofa_1(Clone)":
                lengthGameObject.text = "1.39 m";
                widthGameObject.text = "0.59 m";
                heigthGameObject.text = "0.51 m";
                break;
            case "Sofa_2(Clone)":
                lengthGameObject.text = "1.42 m";
                widthGameObject.text = "0.59 m";
                heigthGameObject.text = "0.52 m";
                break;
            case "Sofa_3(Clone)":
                lengthGameObject.text = "2.16 m";
                widthGameObject.text = "0.59 m";
                heigthGameObject.text = "0.51 m";
                break;
            case "Table_1(Clone)":
                lengthGameObject.text = "1.70 m";
                widthGameObject.text = "0.90 m";
                heigthGameObject.text = "1.00 m";
                break;
            case "Table_2(Clone)":
                lengthGameObject.text = "1.48 m";
                widthGameObject.text = "0.88 m";
                heigthGameObject.text = "0.86 m";
                break;
            case "Table_3(Clone)":
                lengthGameObject.text = "1.60 m";
                widthGameObject.text = "0.90 m";
                heigthGameObject.text = "0.60 m";
                break;
        }
    }

    private void GetModelObjData(GameObject gameObject)
    {
        var objData = InstantiatedGameObject._obj.GetInstantiatedModelObj(gameObject);

        lengthGameObject.text = (objData.GetObjLength()/100).ToString() + " m";
        widthGameObject.text = "0.5 m";
        heigthGameObject.text = ((objData.GetScale().y + 10)/100).ToString() + " m";
    }

}
