using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAttraction : MonoBehaviour
{
    private float _radius; // 10 x of scale
    public float _force = 0.1f;

    void Start()
    {
        _radius = transform.localScale.x * 10;
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && col.attachedRigidbody != null)
            {
                Vector3 forceDirection = (transform.position - col.transform.position).normalized;
                col.attachedRigidbody.AddForce(forceDirection * _force);
            }
        }
    }
}
