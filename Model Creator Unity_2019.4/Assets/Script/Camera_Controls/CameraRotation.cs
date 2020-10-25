using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Joystick joyStick;
    private UnityPublicVariables publicVariables;

    // Start is called before the first frame update
    void Start()
    {
        publicVariables = Interface._obj.GetClassRefrence_UPV();
        joyStick = publicVariables.GetRotationJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if (Interface._obj.GetRotJoystickDrag())
        {
            if (!Interface._obj.GetCameraMode_Ortho())
            {
                var x = joyStick.Vertical * publicVariables.GetRotationSpeed() * publicVariables.GetRotationDirection() * Time.deltaTime;
                var y = -joyStick.Horizontal * publicVariables.GetRotationSpeed() * publicVariables.GetRotationDirection() * Time.deltaTime;
                this.gameObject.transform.eulerAngles += new Vector3(x, y, 0);
                
            }
        } 
    }

}
