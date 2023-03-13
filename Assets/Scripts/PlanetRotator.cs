using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    [SerializeField] private float _minTorque = 20f;
    [SerializeField] private float _maxTorque = 200f;

    private Rigidbody _rb;

    // Add a random torque to the object
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        float torque = Random.Range(_minTorque, _maxTorque);
        _rb.AddTorque(Random.onUnitSphere * torque);
    }//OnEnable

}//class
