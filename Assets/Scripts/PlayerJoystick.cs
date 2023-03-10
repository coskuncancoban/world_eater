using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    private float speed = 10f;
    private DynamicJoystick variableJoystick;
    private Rigidbody rb;


    private void OnEnable()
    {

        rb = GetComponent<Rigidbody>();

        Canvas canvas = GameObject.FindGameObjectWithTag("TouchCanvas").GetComponent<Canvas>();
        variableJoystick = canvas.GetComponentInChildren<DynamicJoystick>();
    }


    public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
