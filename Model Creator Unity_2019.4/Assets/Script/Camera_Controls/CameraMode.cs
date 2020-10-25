using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraMode : MonoBehaviour, IPointerClickHandler
{
    private Sprite camreaSprite_Presp;
    private Sprite camreaSprite_Iso;
    private Image spriteRenderer;
    
    void Start()
    {
        camreaSprite_Presp = Interface._obj.GetClassRefrence_UPV().GetCameraSprite_Presp();
        camreaSprite_Iso = Interface._obj.GetClassRefrence_UPV().GetCameraSprite_Iso();

        spriteRenderer = this.gameObject.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (!Interface._obj.GetCameraMode_Ortho())
        {
            Interface._obj.SetCameraAngle_PrespMode(Camera.main.transform.eulerAngles);

            CameraSettings(camreaSprite_Iso, true, new Vector3(90f, 0, 0), 15);

        }
        else
        {
            var cameraAngle = Interface._obj.GetCameraAngle_PrepMode();
            CameraSettings(camreaSprite_Presp, false, cameraAngle, 4);

        }
    }

    private void CameraSettings(Sprite sprite, bool cameraMode, Vector3 cameraAngle, int cameraHeight)
    {
        spriteRenderer.sprite = sprite;
        Interface._obj.SetCameraMode_Ortho(cameraMode);

        Camera.main.transform.eulerAngles = cameraAngle;
        var x = Camera.main.transform.position.x;
        var z = Camera.main.transform.position.z;
        Camera.main.transform.position = new Vector3(x, cameraHeight, z);
    }

}
