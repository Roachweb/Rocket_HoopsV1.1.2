using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour {

    public GameObject Ball;

    public GameObject[] ranSpawn;
    //public spawnPoint coinPrefab;

    GameObject SpawnPoint;
    
    // Use this for initialization
    void Start () {

        //SpawnPoint = ranSpawn[Random.Range(0, ranSpawn.Length)];
        //Instantiate(SpawnPoint, this.transform.position, this .transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {

        /*if (!Ball.activeInHierarchy)
        {
            SpawnPoint = ranSpawn[Random.Range(0, ranSpawn.Length)];
            Instantiate(SpawnPoint, this.transform.position, this.transform.rotation);
        }
        else if (Ball.activeInHierarchy)
        {
        Ball.SetActive(false);
            Debug.LogWarning("There's a ball");
        }*/
        //^
        ////BookMark//// Respawn after despawn
        //v
        while (SpawnPoint == null)
            {
                SpawnPoint = ranSpawn[Random.Range(0, ranSpawn.Length)];
                Instantiate(SpawnPoint, this.transform.position, this.transform.rotation);
            }
            if (!Ball.activeInHierarchy)
            {
                Ball.SetActive(true);
                Debug.LogWarning("There's a ball");
                Debug.LogWarning(Ball.activeInHierarchy);
        }
    }

}
