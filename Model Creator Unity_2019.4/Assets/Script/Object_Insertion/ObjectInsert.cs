using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInsert : MonoBehaviour
{
    private GameObject selectedObject;
    private Color modelObjColor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.selectedObject = Interface._obj.GetSelectedObject();
            var modelObj = Interface._obj.GetSelected_ModelObj();
            var interiorObj = Interface._obj.GetSelected_InteriorObj();


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!( hit.collider.gameObject.name.Contains("wall") || 
                    hit.collider.gameObject.name.Contains("window") || 
                    hit.collider.gameObject.name.Contains("door") ) )
                {

                    if (modelObj || interiorObj)
                    {
                        Plane plane = new Plane(Vector3.up, Vector3.zero);

                        if (plane.Raycast(ray, out float distance))
                        {
                            Vector3 point = ray.GetPoint(distance);

                            if (interiorObj && !modelObj)
                                InteriorObject(point);
                            else if (!interiorObj && modelObj)
                            {
                                if (selectedObject.name.Contains("wall"))
                                    modelObjColor = Color.white;
                                else if (selectedObject.name.Contains("window"))
                                    modelObjColor = Color.red;
                                else if (selectedObject.name.Contains("door"))
                                    modelObjColor = Color.yellow;
                                ModelObject(point);
                            }

                        }

                        Interface._obj.SetSelectedObject(null);
                        Interface._obj.SetSelected_ModelObj(false);
                        Interface._obj.SetSelected_InteriorObj(false);

                    }

                }
            }

            
        }
    }

    private void InteriorObject(Vector3 point)
    {
        var createObj = new CreateGameObject();

        point.y = 0.06f;
        var gameObject = createObj.InstantiateGameObj(selectedObject, point);
        gameObject.transform.eulerAngles = new Vector3(Interface._obj.GetAngle_InteriorObj(), 0, 0);

        if (Interface._obj.GetCameraMode_Ortho())
            gameObject.GetComponent<ObjectDrag>().enabled = true;
        
        var interiorObj = new GameObject_Interior();
        interiorObj.SetGameObject(gameObject, gameObject.transform.position, gameObject.transform.eulerAngles, selectedObject.name);

        InstantiatedGameObject._obj.AddGameObjectInterior(interiorObj);
    }

    private void ModelObject(Vector3 point)
    {
        var createObj = new CreateGameObject();

        point.y = 0.06f;
        var gameObject = createObj.InstantiateGameObj(selectedObject, point, true);
        gameObject = createObj.GameObjSetting(gameObject, new Vector3(0, 90, 50), new Vector3(0, 0, 0), Color.white);


        if (Interface._obj.GetCameraMode_Ortho())
            gameObject.GetComponent<ObjectDrag>().enabled = true;

        var modelObj = new GameObject_Model();
        modelObj.SetGameObject(gameObject, gameObject.transform.position, gameObject.transform.localScale, gameObject.transform.eulerAngles, Color.white, selectedObject.name, 50);

        InstantiatedGameObject._obj.AddGameObjectModel(modelObj);
    }

}
