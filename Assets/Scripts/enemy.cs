using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {

    Rigidbody rb;
    Animator anim;

    public GameObject spiderOB;
    public GameObject AItarget;

    public float speed;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (speed == 0)
        {
            speed = 6;
        }

        //spiderOB = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        spiderOB.transform.LookAt(AItarget.transform.position);

        float step = speed * Time.deltaTime;

        if (Physics.Raycast(spiderOB.transform.position, spiderOB.transform.forward, out hit, Mathf.Infinity))// finds colliders //line cast detects cast inbetween
        {
            //Debug.Log(hit.collider.name);
            //Debug.Log(step);
            //Debug.Log(speed);

            if (hit.collider.name == "ColliderFrontt")
            { //Dont Move
                anim.SetFloat("mov", -3);
                anim.SetBool("invis", true);
                spiderOB.transform.position = Vector3.MoveTowards(spiderOB.transform.position, AItarget.transform.position, 0);
                rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX; ;
            }
            else
            { //Moving
                anim.SetFloat("mov", 3);
                anim.SetBool("invis", false);
                spiderOB.transform.position = Vector3.MoveTowards(spiderOB.transform.position, AItarget.transform.position, step);
                
            }
        }
       
    }
    //Notes 
    void OnControllerColliderHit(ControllerColliderHit c)
    {
        //will happen every time it's true
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("lookForGroup");
           // Switch to player
                //Player will play death animation
                //Animation will trigger scene change function
        }
    }

    
}


