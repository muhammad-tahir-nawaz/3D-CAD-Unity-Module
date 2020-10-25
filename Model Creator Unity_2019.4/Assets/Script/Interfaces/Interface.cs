using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This is a Singleton Class.
public class Interface
{
    // Singleton variable
    public static readonly Interface _obj = new Interface();

    // UnityPublicVaribale class refrence
    private UnityPublicVariables classRef;

    // SceneLoading class
    private bool sceneLoaded;
    private bool modelCreateScene; // True: if to load ModelCreate Scene
    private bool modelLoadScene; // True: if to load ModelLoad Scene

    // Model Loading (LoadModelLoadScene, BacKModelCreateScene)
    private bool backButtonActive;

    // ObjectColor class
    private Color selectedColor = Color.white; // Color selected by the user
    private bool applyColor = false; // Apply selected color to the touched obj if ture

    // Panel_Control class
    private bool panelActive; // Whether any panel is active currently
    private string activePanelName;

    // ObjectReplace_Model, ObjectInsert (for model objects)
    private GameObject selectedObject;
    private bool selected_ModelObj;
    private bool selected_InteriorObj;
    private int angle_InteriorObj;

    // ObjectDrag, Instantiate_UIElements
    private bool dragObj;

    // ObjectRotate, ObjectRotateControl
    private bool rotateObj;

    // Angle_JoyStickDrag, CameraRotation
    private bool rotJoystickDrag;

    // Movement_JoystickDrag, CameraMovement
    private bool moveJoystickDrag;

    // CameraMovement
    private bool cameraMode_Iso;

    // CameraMode
    private Vector3 cameraAngle_PrespMode;

    // LoadFile
    private bool savedFile;
    private bool tempFile;
    private bool[] selectedFile;

    // Disable_UIElements
    private bool panelRayCastDisable;

    // InteriorObjInfo
    private bool objInfoPanelState;

    public UnityPublicVariables GetClassRefrence_UPV()
    {
        return classRef;
    }
    public void SetClassRef(UnityPublicVariables classRef)
    {
        this.classRef = classRef;
    }


    public bool GetSceneLoaded()
    {
        return sceneLoaded;
    }
    public void SetSceneLoaded(bool state)
    {
        this.sceneLoaded = state;
    }
    public bool GetModelCreateScene()
    {
        return modelCreateScene;
    }
    public void SetModelCreateScene(bool state)
    {
        this.modelCreateScene = state;
    }
    public bool GetModelLoadScene()
    {
        return modelLoadScene;
    }
    public void SetModelLoadScene(bool state)
    {
        this.modelLoadScene = state;
    }


    public bool GetBackButtonActive()
    {
        return backButtonActive;
    }
    public void SetBackButtonActive(bool state)
    {
        this.backButtonActive = state;
    }


    public bool GetApplyColor()
    {
        return applyColor;
    }
    public void SetApplyColor(bool state)
    {
        this.applyColor = state;
    }


    public Color GetSelectedColor()
    {
        return selectedColor;
    }
    public void SetSelectedColor(Color selectedColor)
    {
        this.selectedColor = selectedColor;
    }


    public bool GetPanelActive()
    {
        return panelActive;
    }
    public void SetPanelActive(bool state)
    {
        this.panelActive = state;
    }
    public string GetActivePanelName()
    {
        return activePanelName;
    }
    public void SetActivePanelName(string activePanelName)
    {
        this.activePanelName = activePanelName;
    }


    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }
    public void SetSelectedObject(GameObject gameObject)
    {
        selectedObject = gameObject;
    }
    public bool GetSelected_ModelObj()
    {
        return selected_ModelObj;
    }
    public void SetSelected_ModelObj(bool state)
    {
        selected_ModelObj = state;
    }
    public bool GetSelected_InteriorObj()
    {
        return selected_InteriorObj;
    }
    public void SetSelected_InteriorObj(bool state)
    {
        selected_InteriorObj = state; 
    }
    public int GetAngle_InteriorObj()
    {
        return angle_InteriorObj;
    }
    public void SetAngle_InteriorObj(int angle)
    {
        this.angle_InteriorObj = angle;
    }


    public bool GetDragObj()
    {
        return dragObj;
    }
    public void SetDragObj(bool state)
    {
        this.dragObj = state;
    }


    public bool GetRotateObj()
    {
        return rotateObj;
    }
    public void SetRotaeObj(bool state)
    {
        this.rotateObj = state;
    }


    public bool GetRotJoystickDrag()
    {
        return rotJoystickDrag;
    }
    public void SetRotJoystickDrag(bool state)
    {
        this.rotJoystickDrag = state;
    }


    public bool GetMoveJoystickDrag()
    {
        return moveJoystickDrag;
    }
    public void SetMoveJoystickDrag(bool state)
    {
        this.moveJoystickDrag = state;
    }


    public bool GetCameraMode_Ortho()
    {
        return cameraMode_Iso;
    }
    public void SetCameraMode_Ortho(bool state)
    {
        this.cameraMode_Iso = state;
    }


    public Vector3 GetCameraAngle_PrepMode()
    {
        return cameraAngle_PrespMode;
    }
    public void SetCameraAngle_PrespMode(Vector3 cameraAngle)
    {
        this.cameraAngle_PrespMode = cameraAngle;
    }


    public bool GetSavedFile()
    {
        return savedFile;
    }
    public void SetSavedFile(bool state)
    {
        this.savedFile = state;
    }
    public bool GetTempFile()
    {
        return tempFile;
    }
    public void SetTempFile(bool state)
    {
        this.tempFile = state;
    }
    public bool[] GetSelectedFile()
    {
        if(selectedFile == null)
            return new bool[6];
        
        return selectedFile;
    }
    public void SetSelectedFile(bool[] states)
    {
        this.selectedFile = states;
    }


    public bool GetPanelRayCastDisable()
    {
        return panelRayCastDisable;
    }


    public void SetPanelRayCastDisable(bool state)
    {
        this.panelRayCastDisable = state;
    }


    public bool GetObjInfoPanelState()
    {
        return objInfoPanelState;
    }
    public void SetObjInfoPanelState(bool state)
    {
        this.objInfoPanelState = state;
    }

}
