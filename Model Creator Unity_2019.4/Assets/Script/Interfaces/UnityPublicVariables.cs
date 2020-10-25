using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class UnityPublicVariables : MonoBehaviour
{

    // CreateModel script variables
    public GameObject doorPrefab;
    public GameObject wallPrefab;
    public GameObject windowPrefab;

    // Instantiate_UIElements script variable
    public Canvas canvas;

    // Panel_Control script variables
    public GameObject decorationPanel;
    public GameObject furniturePanel;
    public GameObject windowPanel;
    public GameObject colorPanel;
    public GameObject savePanel;

    // InteriorObjInfo script variables
    public GameObject objectInfo;
    public TMPro.TextMeshProUGUI ioInteriorObjLength;
    public TMPro.TextMeshProUGUI ioInteriorObjWidth;
    public TMPro.TextMeshProUGUI ioInteriorObjHeight;

    //UnityPublicVariables
    public TMPro.TextMeshProUGUI saveButtonText_1;
    public TMPro.TextMeshProUGUI saveButtonText_2;
    public TMPro.TextMeshProUGUI saveButtonText_3;
    public TMPro.TextMeshProUGUI saveButtonText_4;
    public TMPro.TextMeshProUGUI saveButtonText_5;
    public TMPro.TextMeshProUGUI saveButtonText_6;
    public GameObject overwritePanel;
    public GameObject subSavePanel;

    // CameraRoatation script variables
    public float rotationSpeed = 30;
    public int rotationDirection = -1;
    public Joystick rotationJoystick;

    // CameraMovement script variables
    public float moveSpeed = 10;
    public Joystick movementJoystick;

    // CameraMode script variables
    public Sprite camreaSprite_Presp;
    public Sprite camreaSprite_Iso;


    public void Start()
    {
        var path = "";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = null;
        SaveFilesData saveData;

        var fileName = new string[6];
        for (var iter = 0; iter < 6; iter++)
        {
            path = Application.persistentDataPath + ("/file" + (iter + 1) + "Data.save");
            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Open);

                saveData = formatter.Deserialize(stream) as SaveFilesData;
                fileName[iter] = saveData.FileName;

            }
        }
        stream.Close();
        saveButtonText_1.text = fileName[0];
        saveButtonText_2.text = fileName[1];
        saveButtonText_3.text = fileName[2];
        saveButtonText_4.text = fileName[3];
        saveButtonText_5.text = fileName[4];
        saveButtonText_6.text = fileName[5];
    }

    public GameObject GetDoorPrefab()
    {
        return doorPrefab;
    }
    public GameObject GetWallPrefab()
    {
        return wallPrefab;
    }
    public GameObject GetWindowPrefab()
    {
        return windowPrefab;
    }

    public Canvas GetCanvas()
    {
        return canvas;
    }

    public GameObject GetDecorationPanel()
    {
        return decorationPanel;
    }
    public GameObject GetFurniturePanel()
    {
        return furniturePanel;
    }
    public GameObject GetWindowPanel()
    {
        return windowPanel;
    }
    public GameObject GetColorPanel()
    {
        return colorPanel;
    }
    public GameObject GetSavePanel()
    {
        return savePanel;
    }

    public GameObject GetObjectInfo()
    {
        return objectInfo;
    }
    public TMPro.TextMeshProUGUI GetIOInteriorObjLength()
    {
        return ioInteriorObjLength;
    }
    public TMPro.TextMeshProUGUI GetIOInteriorObjWidth()
    {
        return ioInteriorObjWidth;
    }
    public TMPro.TextMeshProUGUI GetIOInteriorObjHeight()
    {
        return ioInteriorObjHeight;
    }

    public GameObject GetOverwritePanel()
    {
        return overwritePanel;
    }
    public GameObject GetSubSavePanel()
    {
        return subSavePanel;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }
    public int GetRotationDirection()
    {
        return rotationDirection;
    }
    public Joystick GetRotationJoystick()
    {
        return rotationJoystick;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public Joystick GetMovementJoystick()
    {
        return movementJoystick;
    }

    public Sprite GetCameraSprite_Presp()
    {
        return camreaSprite_Presp;
    }
    public Sprite GetCameraSprite_Iso()
    {
        return camreaSprite_Iso;
    }

    // Used when selecting an object from decoration, furniture or window panel
    public void SelectedObject(GameObject gameObject)
    {
        Interface._obj.SetSelectedObject(gameObject);
    }
    // Used when selecting an object from decoration or furniture panel
    public void SelectedInteriorObj()
    {
        Interface._obj.SetSelected_InteriorObj(true);
        Interface._obj.SetSelected_ModelObj(false);
    }
    // Used when selecting an object from window panel
    public void SelectedModelObj()
    {
        Interface._obj.SetSelected_InteriorObj(false);
        Interface._obj.SetSelected_ModelObj(true);
    }
    // Used when selecting an interior type object
    public void SelectedIntriorObjAngle(int angle)
    {
        Interface._obj.SetAngle_InteriorObj(angle);
    }


    

}
