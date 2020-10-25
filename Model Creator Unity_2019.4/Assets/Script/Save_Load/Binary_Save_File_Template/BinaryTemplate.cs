using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BinaryTemplate
{
    // Model GameObject Data
    public float[,] startPos_Model;//   [TL,3]  ... TL = total length
    public float[,] length_Model;//     [TL,3]
    public float[,] angle_Model;//      [TL,3]
    public float[,] color_Model;//      [TL,4]
    public string[] objName_Model;//    [TL]
    public double[] objLength_Model;//  [TL]

    // Interior GameObjet Data
    public float[,] pos_Interior;//     [TL,3]
    public float[,] angle_Interior;//   [TL,3]
    public string[] objName_Interior;// [TL]

    // Camera Data
    public float[] cameraPosition;
    public float[] cameraAngle;

    public BinaryTemplate(Camera mainCamera)
    {
        

        //Adding Model GameObjet Data:
        StoreModelData();

        //Adding Interior GameObjet Data:
        StoreInteriorData();

        //Adding Camera Data
        StoreCameraData(mainCamera);
        
        
    }

    private void StoreModelData()
    {
        var iterator = 0;
        Vector3 pos;
        Vector3 angle;
        Vector3 length;
        Color color;

        List<GameObject_Model> instantiatedModelObj = InstantiatedGameObject._obj.GetInstantiatedModelObjList();
        startPos_Model = new float[instantiatedModelObj.Count, 3];
        length_Model = new float[instantiatedModelObj.Count, 3];
        angle_Model = new float[instantiatedModelObj.Count, 3];
        color_Model = new float[instantiatedModelObj.Count, 4];
        objName_Model = new string[instantiatedModelObj.Count];
        objLength_Model = new double[instantiatedModelObj.Count];

        foreach (GameObject_Model modelObj in instantiatedModelObj)
        {
            pos = modelObj.GetStartPos();
            length = modelObj.GetScale();
            angle = modelObj.GetAngle();
            color = modelObj.GetColor();

            startPos_Model[iterator, 0] = pos.x;
            startPos_Model[iterator, 1] = pos.y;
            startPos_Model[iterator, 2] = pos.z;

            length_Model[iterator, 0] = length.x;
            if (modelObj.GetObjName().Contains("wall"))
            {
                length_Model[iterator, 1] = 20;
            }
            else
            {
                length_Model[iterator, 1] = 40;
            }
            
            length_Model[iterator, 2] = length.z;

            angle_Model[iterator, 0] = angle.x;
            angle_Model[iterator, 1] = angle.y;
            angle_Model[iterator, 2] = angle.z;

            color_Model[iterator, 0] = color.r;
            color_Model[iterator, 1] = color.g;
            color_Model[iterator, 2] = color.b;
            color_Model[iterator, 3] = color.a;


            objName_Model[iterator] = modelObj.GetObjName();

            objLength_Model[iterator] = modelObj.GetObjLength();

            iterator++;
        }
    }

    private void StoreInteriorData()
    {
        var iterator = 0;
        Vector3 pos;
        Vector3 angle;

        List<GameObject_Interior> instantiatedInteriorObj = InstantiatedGameObject._obj.GetInstantiatedInteriorObjList();
        pos_Interior = new float[instantiatedInteriorObj.Count, 3];
        angle_Interior = new float[instantiatedInteriorObj.Count, 3];
        objName_Interior = new string[instantiatedInteriorObj.Count];

        foreach (GameObject_Interior interiorObj in instantiatedInteriorObj)
        {
            pos = interiorObj.GetPosition();
            angle = interiorObj.GetAngle();

            pos_Interior[iterator, 0] = pos.x;
            pos_Interior[iterator, 1] = pos.y;
            pos_Interior[iterator, 2] = pos.z;

            angle_Interior[iterator, 0] = angle.x;
            angle_Interior[iterator, 1] = angle.y;
            angle_Interior[iterator, 2] = angle.z;

            objName_Interior[iterator] = interiorObj.GetObjName();
            
            iterator++;
        }
    }

    private void StoreCameraData(Camera mainCamera)
    {
        cameraPosition = new float[3];
        cameraAngle = new float[3];

        cameraPosition[0] = mainCamera.transform.position.x;
        cameraPosition[2] = mainCamera.transform.position.z;

        if (Interface._obj.GetCameraMode_Ortho())
        {
            cameraPosition[1] = 1f;
            
            var angle = Interface._obj.GetCameraAngle_PrepMode();
            cameraAngle[0] = angle.x;
            cameraAngle[1] = angle.y;
            cameraAngle[2] = angle.z;
        }
        else
        {
            cameraPosition[1] = mainCamera.transform.position.y;
            
            cameraAngle[0] = mainCamera.transform.eulerAngles.x;
            cameraAngle[1] = mainCamera.transform.eulerAngles.y;
            cameraAngle[2] = mainCamera.transform.eulerAngles.z;
        }
    }
}
