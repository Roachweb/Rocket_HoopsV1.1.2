using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour {

    public Rigidbody projectile;
    public Transform projectileSpawnPT;
    public float projectileSpeed = 60;

    public float proFireRate;
    float timeSinceLastFire = 0.0f;

    // Use this for initialization
    void Start()
    {
        if (proFireRate == 0)
        {
            proFireRate = 0.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitter;

        if (Physics.Raycast(transform.position, transform.forward, out hitter, Mathf.Infinity))
        {
            if (hitter.collider.gameObject.tag == "enemy")
            {

                if (Time.time > timeSinceLastFire + proFireRate)
                {
                    fire();

                    timeSinceLastFire = Time.time;
                }
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
