using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    private UnityPublicVariables publicVariables;
    private Joystick joyStick;
    
    // Start is called before the first frame update
    void Start()
    {
        publicVariables = Interface._obj.GetClassRefrence_UPV();
        joyStick = publicVariables.GetMovementJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if(Interface._obj.GetMoveJoystickDrag())
        {
            var horizontal = joyStick.Horizontal * publicVariables.GetMoveSpeed() * Time.deltaTime;
            var vertical = joyStick.Vertical * publicVariables.GetMoveSpeed() * Time.deltaTime;

            if (!Interface._obj.GetCameraMode_Ortho())
            {
                if (this.gameObject.transform.position.y + joyStick.Vertical <= 0)
                {
                    this.gameObject.transform.Translate(new Vector3(horizontal, 0, 0));
                }
                else
                {
                    this.gameObject.transform.Translate(new Vector3(horizontal, 0, vertical));
                }
            }
            else
            {
                this.gameObject.transform.Translate(new Vector3(horizontal, vertical, 0));
            }

        }
        
    }


}
