using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreateModel : MonoBehaviour
{
    private GameObject doorPrefab;
    private GameObject wallPrefab;
    private GameObject windowPrefab;

    //Real Data for Real Model
    private List<Vector3> startPosValues, scalValues, rotationValues;
    private List<Color> color_;
    private List<string> objType_;
    private List<double> objectLength;

    // Start is called before the first frame update
    void Start()
    {
        var classRef = GameObject.Find("ScriptManager").GetComponent<UnityPublicVariables>();
        doorPrefab = classRef.GetDoorPrefab();
        wallPrefab = classRef.GetWallPrefab();
        windowPrefab = classRef.GetWindowPrefab();

        Interface._obj.SetClassRef(classRef);


        
        if (!Interface._obj.GetSavedFile() && !Interface._obj.GetTempFile())
        {
            AndroidPluginCallBack androidPlugin = new AndroidPluginCallBack();

            JSONData jSONData = new JSONData();
            string jsonString = androidPlugin.GetJSONString();
            jSONData.JsonDataExtraction(jsonString);

            startPosValues = jSONData.GetStartPosValues();
            scalValues = jSONData.GetScalValues();
            rotationValues = jSONData.GetRotationValues();
            color_ = jSONData.GetColor();
            objType_ = jSONData.GetObjType();
            objectLength = jSONData.GetObjLength();

            RealModel();

        }

    }

    
    private void RealModel()
    {
        var createObj = new CreateGameObject();

        var iteration = 0;
        GameObject instentiatedPrefab = null;
        string prefabName = null;
        while (iteration < startPosValues.Count)
        {
            var modelObj = new GameObject_Model();

            // Creating an object
            if (objType_[iteration].CompareTo("Walls") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(wallPrefab, startPosValues[iteration], false);
                prefabName = wallPrefab.name;
            }
            else if (objType_[iteration].CompareTo("Windows") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(windowPrefab, startPosValues[iteration], true);
                prefabName = windowPrefab.name;
            }
            else if (objType_[iteration].CompareTo("Doors") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(doorPrefab, startPosValues[iteration], false);
                prefabName = doorPrefab.name;
            }
            instentiatedPrefab = createObj.GameObjSetting(instentiatedPrefab, scalValues[iteration], rotationValues[iteration], color_[iteration]);

            // Adding the game object to modelObj
            modelObj.SetGameObject(instentiatedPrefab, startPosValues[iteration], scalValues[iteration], rotationValues[iteration], color_[iteration], prefabName, objectLength[iteration]);

            // Adding the game object to list of instantiated game objects
            InstantiatedGameObject._obj.SetInstantiatedModelObj(modelObj);

            iteration++;
        }
    }


}

/*private void dummyModel()
    {
        var createObj = new CreateGameObject();
        
        var iteration = 0;
        GameObject instentiatedPrefab = null;
        string prefabName = null;
        while (iteration < transformData.GetLength(0))
        {
            var modelObj = new GameObject_Model();

            // Creating an object
            if (objType[iteration].CompareTo("wall") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(wallPrefab, transformData[iteration, 0], false);
                prefabName = wallPrefab.name;
            }
            else if (objType[iteration].CompareTo("window") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(windowPrefab, transformData[iteration, 0], true);
                prefabName = windowPrefab.name;
            }
            else if (objType[iteration].CompareTo("door") == 0)
            {
                instentiatedPrefab = createObj.InstantiateGameObj(doorPrefab, transformData[iteration, 0], false);
                prefabName = doorPrefab.name;
            }
            instentiatedPrefab = createObj.GameObjSetting(instentiatedPrefab, transformData[iteration, 1], rotationData[iteration], color[iteration]);

            // Adding the game object to modelObj
            modelObj.SetGameObject(instentiatedPrefab, transformData[iteration, 0], transformData[iteration, 1], rotationData[iteration], color[iteration], prefabName, 111);

            // Adding the game object to list of instantiated game objects
            InstantiatedGameObject._obj.SetInstantiatedModelObj(modelObj);
            modelObj = null;

            iteration++;

        }
        Interface._obj.SetSceneLoaded(true);

    }
*/
