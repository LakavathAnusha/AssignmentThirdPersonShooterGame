using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawning : MonoBehaviour
{
   /* public GameObject[] zombiePrefabs;
    public int number;
    public float spawnRadius;
    public bool spawnOnStart = true;
    //public GameObject ragDollPrefab;*/

    // Start is called before the first frame update
    void Start()
    {
      /*  if (spawnOnStart)
        {
            CreateAllZombies();

        }*/
    }

    public void CreateAllZombies()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                /*  int k = Random.Range(0, zombiePrefabs.Length);
                  randomPoint.y = 0f;
                  Instantiate(zombiePrefabs[k], randomPoint, Quaternion.identity);*/
                GameObject tempZombie = PoolScript.instance.GetObjectsFromPool("Enemy");
                tempZombie.transform.position = hit.position;
                tempZombie.SetActive(true);

            }
            else
            {
                i--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.R))
         {
             Instantiate(ragDollPrefab, this.transform.position, Quaternion.identity);
             return;
         }*/
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (!spawnOnStart && other.gameObject.tag == "Player")
        {
            CreateAllZombies();

        }
    }*/
}