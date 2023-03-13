using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPool objectPool;
    string objTag = "Planet";

    float spawnInterval;
    [SerializeField] private float force;

    [SerializeField] private List<GameObject> _targets;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        objectPool = ObjectPool.Instance;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            spawnInterval = Random.Range(1f, 4f);
            float force = Random.Range(0.1f, 1f);
            Vector3 forceDirection = (_targets[Random.Range(0, _targets.Count)].transform.position).normalized - transform.position;
            GameObject obj = objectPool.SpawnFromPool(objTag, transform.position, Quaternion.identity);
            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>(); // Burda rigid bodyi alırken hata veriyor!!!   
                rb.AddForce(forceDirection * force, ForceMode.Impulse);
            }
            yield return new WaitForSeconds(spawnInterval);
        }


    }

}
