using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputCon playerInput;
  //  private InputActionMap onFoot;
    private PlayerInputCon.OnFootActions onFoot;  // Using the OnFootActions struct instead of InputActionMap
    private PlayerMotor motor;
   
    public PlayerInputCon.OnFootActions OnFoot => onFoot;
    //seperate accessor thing for syntax 
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInputCon();
        onFoot = playerInput.onFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        //danger
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Sprint.performed += ctx => motor.Sprint();
        // points to jump anytime onfoot jump is called we use a callback to get the motorJump();
        //theres performed, started, or canceled with the call back context (ctx)

    }
    //grabs onFoot InputSystem from script in the Input file

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    { 
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
