using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float lifeT;

	// Use this for initialization
	void Start () {

        lifeT = 0.5f;

	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, lifeT);
	}

    void OnCollisionEnter(Collision c)
    {
        //Debug.Log("Contact");
        if (c.gameObject.tag == "enemy")
        {
            Destroy(c.gameObject);
            Debug.Log("Kill Confirmed");
        }
    }
}
