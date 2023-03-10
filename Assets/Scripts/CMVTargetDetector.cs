using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMVTargetDetector : MonoBehaviour
{
    private Transform _target;

    private CinemachineVirtualCamera _cmv;

    void Start()
    {
        _cmv = GetComponent<CinemachineVirtualCamera>();
        _target = GameObject.FindWithTag("Player").transform;
        _cmv.Follow = _target;
        _cmv.LookAt = _target;

    }//Start

}//class
