using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour {

    Rigidbody rb;

    GameObject Goal;
    GameObject spawn;

    Vector3 datSpin = Vector3.zero;

    // Use this for initialization
    void Start () {
        Goal = GameObject.FindGameObjectWithTag("Goal");
        spawn = GameObject.FindGameObjectWithTag("spawn");
        rb = GetComponent<Rigidbody>();
        Vector3 datSpin = new Vector3(0,1,0);
    }
	
	// Update is called once per frame
	void Update () {

        ////BookMark//// Respawn after despawn
        if (!this.gameObject.activeInHierarchy)
        {
            Debug.Log("active was set false");
            transform.position = spawn.transform.position;
            gameObject.SetActive(true);

        }

	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, Goal.transform.position, 1);
            Debug.LogWarning("Hype");
            rb.MoveRotation(Quaternion.AngleAxis(30, datSpin));
            //add force explosion
            
            //gameObject.SetActive(false);//test
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "goal")
        {
            
            Debug.LogWarning("Point Hype");
            gameObject.SetActive(false);
            //Destroy(gameObject, 3);
        }
    }
}
