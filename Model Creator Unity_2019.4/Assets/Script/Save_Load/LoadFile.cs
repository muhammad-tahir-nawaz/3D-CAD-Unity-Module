using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadFile : MonoBehaviour
{
    private BinaryTemplate binaryTemp;

    // Start is called before the first frame update
    void Start()
    {
        LoadSavedFile();
    }


    private void LoadSavedFile()
    {
        string path = null;
        
        if(Interface._obj.GetSavedFile() || Interface._obj.GetTempFile())
        {
            if (Interface._obj.GetSavedFile() || !Interface._obj.GetTempFile())
                for (var i = 0; i < 6; i++)
                {
                    if (Interface._obj.GetSelectedFile()[i])
                    {
                        path = Application.persistentDataPath + "/saveFile" + (i + 1) + ".save";
                        break;
                    }
                }
            else if (!Interface._obj.GetSavedFile() || Interface._obj.GetTempFile())
                path = Application.persistentDataPath + ("/tempSave.save");

            if (path != null && File.Exists(path))
            {
                InstantiatedGameObject._obj.EmptyLists();

                // Bring data from saved file
                DeserializeSavedFile(path);
                // Create 3D model
                InstantiateModelObjects();
                // Create decoration objects present
                InstantiateInteriorObjects();
                // Set camera position & angle
                AssignCameraData();
            }
        }
    }

    private void DeserializeSavedFile(string path)
    {
        var formatter = new BinaryFormatter();
        var stream = new FileStream(path, FileMode.Open);

        this.binaryTemp = formatter.Deserialize(stream) as BinaryTemplate;
        stream.Close();
    }

    private void InstantiateModelObjects()
    {
        GameObject gameObject = null;
        GameObject prefab = null;
        var createObj = new CreateGameObject();

        Vector3 pos;
        Vector3 length;
        Vector3 angle;
        Color color;
        double objLength;

        //Loading Model GameObjects:
        for (var i = 0; i < this.binaryTemp.objName_Model.Length; i++)
        {
            var modelObj = new GameObject_Model();

            pos = new Vector3(binaryTemp.startPos_Model[i, 0], binaryTemp.startPos_Model[i, 1], binaryTemp.startPos_Model[i, 2]);
            length = new Vector3(binaryTemp.length_Model[i, 0], binaryTemp.length_Model[i, 1], binaryTemp.length_Model[i, 2]);
            angle = new Vector3(binaryTemp.angle_Model[i, 0], binaryTemp.angle_Model[i, 1], binaryTemp.angle_Model[i, 2]);
            color = new Color(binaryTemp.color_Model[i, 0], binaryTemp.color_Model[i, 1], binaryTemp.color_Model[i, 2], binaryTemp.color_Model[i, 3]);
            prefab = (GameObject)Resources.Load("prefabs/" + binaryTemp.objName_Model[i], typeof(GameObject));
            objLength = binaryTemp.objLength_Model[i];

            // Instantiate object
            if (prefab.name.Contains("window"))
                gameObject = createObj.InstantiateGameObj(prefab, pos, true);
            else
                gameObject = createObj.InstantiateGameObj(prefab, pos, false);

            // Setting objects data
            gameObject = createObj.GameObjSetting(gameObject, length, angle, color);

            // Adding the game object to modelObj
            modelObj.SetGameObject(gameObject, pos, length, angle, color, prefab.name, objLength);

            // Adding the game object to list of instantiated game objects
            InstantiatedGameObject._obj.SetInstantiatedModelObj(modelObj);
        }
    }

    private void InstantiateInteriorObjects()
    {
        GameObject gameObject = null;
        GameObject prefab = null;
        var createObj = new CreateGameObject();

        Vector3 pos;
        Vector3 angle;

        //Loading Interior GameObjects:
        for (var i = 0; i < this.binaryTemp.objName_Interior.Length; i++)
        {
            var interiorObj = new GameObject_Interior();

            pos = new Vector3(binaryTemp.pos_Interior[i, 0], binaryTemp.pos_Interior[i, 1], binaryTemp.pos_Interior[i, 2]);
            angle = new Vector3(binaryTemp.angle_Interior[i, 0], binaryTemp.angle_Interior[i, 1], binaryTemp.angle_Interior[i, 2]);
            prefab = (GameObject)Resources.Load("prefabs/" + binaryTemp.objName_Interior[i], typeof(GameObject));

            // Instantiate object
            gameObject = createObj.InstantiateGameObj(prefab, pos);

            // Setting objects data
            gameObject = createObj.GameObjSetting(gameObject, angle);

            //adding the game object to modelObj
            interiorObj.SetGameObject(gameObject, pos, angle, prefab.name);
            //adding the game object to list of instantiated game objects
            InstantiatedGameObject._obj.SetInstantiatedInteriorObj(interiorObj);
        }
    }

    private void AssignCameraData()
    {
        //Loading Camera Data:
        Camera.main.transform.position = new Vector3(binaryTemp.cameraPosition[0], binaryTemp.cameraPosition[1], binaryTemp.cameraPosition[2]);
        Camera.main.transform.eulerAngles = new Vector3(binaryTemp.cameraAngle[0], binaryTemp.cameraAngle[1], binaryTemp.cameraAngle[2]);
        Interface._obj.SetCameraMode_Ortho(false);
    }

}
