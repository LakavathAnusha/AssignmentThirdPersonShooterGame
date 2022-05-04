using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static PoolScript instance;
    public List<GameObject> pool = new List<GameObject>();
    public List<PoolObject> poolItems = new List<PoolObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }
    void Start()
    {
        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {

        }*/

    }

    public void AddToPool()
    {
        foreach (PoolObject item in poolItems)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject temp = Instantiate(item.prefab);
                temp.SetActive(false);
                pool.Add(temp);

            }
        }
    }
    /* public GameObject GetObjectsFromPool(string tagname)
     {
         for(int i=0;i<pool.Count;i++)
         {   if(pool[i].gameObject.tag == tagname)
             {
                 return pool[i].gameObject;
                // pool[i].gameObject.SetActive(true);
             }

         }
     }*/
    public GameObject GetObjectsFromPool(string tagname)
    {
        foreach (GameObject item in pool)
        {
            if (item.gameObject.tag == tagname && !item.activeInHierarchy)
            {
                return item;
                // pool[i].gameObject.SetActive(true);
            }

        }
        return null;

    }
}

[System.Serializable]
public class PoolObject
{
    public GameObject prefab;
    public string name;
    public int amount;
}