using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenemePrefab : MonoBehaviour
{
    public class PrefabLauncher : MonoBehaviour
{
    public GameObject prefab;
    public float launchForce = 1000f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            LaunchPrefab();
        }
    }

    void LaunchPrefab()
    {
        GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);
        Rigidbody[] childRbs = newObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody childRb in childRbs)
        {
            childRb.AddForce(transform.right * launchForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prefab"))
        {
            GameObject collidedObject = collision.gameObject;
            Destroy(collidedObject);
            LaunchPrefab();
        }
    }
}
}
