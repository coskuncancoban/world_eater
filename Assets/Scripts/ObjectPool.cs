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

    /* 
     private Queue<GameObject> _planetPool;
     [SerializeField] private GameObject[] _planetPrefabs;
     [SerializeField] private int _planetPoolSize;

     private Queue<GameObject> _asteroidPool;
     [SerializeField] private GameObject[] _asteroidPrefabs;
     [SerializeField] private int _asteroidPoolSize;
 */


    private void Awake()
    {

        Instance = this;
        /*
            _planetPool = new Queue<GameObject>();
            _asteroidPool = new Queue<GameObject>();
            */
    }


    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs[Random.Range(0, pool.prefabs.Length)]);
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

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }



























}
