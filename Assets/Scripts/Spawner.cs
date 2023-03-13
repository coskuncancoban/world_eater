using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPool objectPool;

    private void Start() {
        objectPool = ObjectPool.Instance;
    }


    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject obj = objectPool.SpawnFromPool("Planet", transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
    }



}
