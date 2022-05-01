using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    float time;
    float healthTime;
    //float healthTime;
   // PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
            time = time + Time.deltaTime;
        if (time > 3f)
        {
            // GameObject temp=Instantiate(ObjectPoolScript.instance.GetObjectsFromPool("Asteroid"),new Vector3(Random.Range(-8.0f, 8f),4f,0f),Quaternion.identity);
            GameObject tempEnemy =PoolScript.instance.GetObjectsFromPool("Enemy");
            if (tempEnemy != null)
            {
                tempEnemy.transform.position = new Vector3(Random.Range(-8.0f, 8f), 1f, Random.Range(-6.0f, 6f));
                tempEnemy.SetActive(true);
            }
            time = 0;
        }
        healthTime = healthTime + Time.deltaTime;
        if (healthTime > 3f)
        {
            GameObject tempHealth = (PoolScript.instance.GetObjectsFromPool("Health"));
            if (tempHealth != null)
            {
                tempHealth.transform.position = new Vector3(Random.Range(-8.0f, 8f), 4f, Random.Range(-8.0f, 8f));
                tempHealth.SetActive(true);
            }
            healthTime = 0;
        }
    }
}