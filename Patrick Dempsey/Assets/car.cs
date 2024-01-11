using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class car : MonoBehaviour
{
    [SerializeField]WheelJoint2D backWheel;
    [SerializeField]WheelJoint2D frontWheel;

     [SerializeField]wheel backWheelScript;
    [SerializeField]wheel frontWheelScript;
    [SerializeField]float motorForce;
    [SerializeField] float turnSpeed;
    [SerializeField]Transform camera;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera.position = new Vector3(transform.position.x, transform.position.y, camera.position.z);
    }

    public void Drive(InputAction.CallbackContext ctx){
        float val = ctx.ReadValue<float>();
        JointMotor2D motor = backWheel.motor;
        motor.motorSpeed = val * motorForce * -1;
        backWheel.motor = motor;
        frontWheel.motor = motor;
    }

    public void Rotate(InputAction.CallbackContext ctx){
        float val = ctx.ReadValue<float>();
        rb.angularVelocity = val * turnSpeed;
    }

    public void Jump(){
        if(frontWheelScript.grounded || backWheelScript.grounded){
        rb.AddForce(new Vector2(0,jumpForce));
        }
    }

}
