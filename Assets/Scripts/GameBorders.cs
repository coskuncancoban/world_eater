using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorders : MonoBehaviour
{

    ObjectPool objectPool;

    private void Start()
    {
        objectPool = ObjectPool.Instance;
    }


    private void OnCollisionEnter(Collision other)
    {
        //other.gameObject.SetActive(false);
        if (other.gameObject.CompareTag("Planet"))
        {
            objectPool.ReturnToPool(other.gameObject);
        }
        else{
            other.gameObject.SetActive(false);
        }


    }
}
