using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guns : MonoBehaviour {

    CharacterController cc;

    public Rigidbody projectile;
    public Transform projectileSpawnPT;
    public float projectileSpeed = 60;

    public float proFireRate;
    float timeSinceLastFire = 0.0f;

    // Use this for initialization
    void Start () {
        if (proFireRate == 0)
        {
            proFireRate = 0.5f;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Z))
        {
            if (Time.time > timeSinceLastFire + proFireRate)
            {
                fire();

                timeSinceLastFire = Time.time;
            }
        }

	}

    void fire()
    {
        if (projectile)
        {
            Rigidbody rb = Instantiate(projectile, projectileSpawnPT.position, projectileSpawnPT.rotation) as Rigidbody;

            rb.AddForce(projectileSpawnPT.forward * projectileSpeed, ForceMode.Impulse);
        }

    }
}
