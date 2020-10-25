using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectReplace_Model : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Interface._obj.GetSelected_ModelObj())
        {
            var modelObj = Interface._obj.GetSelectedObject();

            var oldModel = InstantiatedGameObject._obj.GetInstantiatedModelObj(this.gameObject);
            var createObj = new CreateGameObject();

            var objColor = Color.white; // color of wall will be the default "WHITE"
            if (modelObj.name.Contains("window"))
                objColor = Color.red;
            else if (modelObj.name.Contains("door"))
                objColor = Color.yellow;

            var gameObject = createObj.InstantiateGameObj(modelObj, oldModel.GetStartPos(), true);
            gameObject = createObj.GameObjSetting(gameObject, oldModel.GetScale(), oldModel.GetAngle(), objColor);

            var newModel = new GameObject_Model();
            newModel.SetGameObject(gameObject, oldModel.GetStartPos(), oldModel.GetScale(), oldModel.GetAngle(), objColor, modelObj.name, oldModel.GetObjLength());

            InstantiatedGameObject._obj.SetInstantiatedModelObj(newModel);
            InstantiatedGameObject._obj.DeleteGameObjectModel(oldModel);

            Destroy(this.gameObject);

            Interface._obj.SetSelected_InteriorObj(false);
            Interface._obj.SetSelected_ModelObj(false);
            Interface._obj.SetSelectedObject(null);

        }

    }
}
