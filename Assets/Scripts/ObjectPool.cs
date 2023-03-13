using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject[] prefabs;
        public int size;
    }

    public static ObjectPool Instance;




    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
    
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs[Random.Range(0, pool.prefabs.Length)], transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);

        }

    }



    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        if (poolDictionary[tag].Count == 0)
        {
            Debug.LogWarning("Pool with tag " + tag + " is empty.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        poolDictionary[obj.tag].Enqueue(obj);
    }



























}
