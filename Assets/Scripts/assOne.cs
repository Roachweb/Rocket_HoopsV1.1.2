using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class assOne : MonoBehaviour {

    float Vex = 20.0f;
    float gravity = -9.81f;
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position += new Vector3(Vex * Time.fixedDeltaTime, gravity * Time.fixedDeltaTime, 0);

        
	}
}
