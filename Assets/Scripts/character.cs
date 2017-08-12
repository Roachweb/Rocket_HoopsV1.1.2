using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class character : MonoBehaviour {

    CharacterController cc;

   

    public float charSpeed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float gravity;

    public bool isruning;

    public int type = 1;

    Vector3 moveDirection;

    public Rigidbody projectile;
    public Transform projectileSpawnPT;
    public float projectileSpeed = 10;

    Animator anim;

    static int idleState = Animator.StringToHash("Base Layer.idle");


    AnimatorStateInfo curStat;

    // Use this for initialization
    void Start () {

        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();


        charSpeed = 6.0f;
        rotationSpeed = 5.0f;
        jumpSpeed = 8.0f;
        gravity = 9.81f;

        moveDirection = Vector3.zero;

       
        isruning = false;


	}
	
	// Update is called once per frame
	void Update () {

        //simple movement
        if (type == 0)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

            float curSpeed = Input.GetAxis("Vertical") * charSpeed;

            //global forward
            //cc.SimpleMove(Vector3.forward * curSpeed);

            //local forward
            cc.SimpleMove(transform.forward * curSpeed);

        }

        else if (type == 1)
        {
            if (cc.isGrounded)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

                transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

                if (!isruning)
                    moveDirection *= charSpeed;
                else if (isruning)
                    moveDirection = (moveDirection * charSpeed) * 1.5f;


                moveDirection = transform.TransformDirection(moveDirection);
                if (curStat.fullPathHash != idleState)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        moveDirection.y = jumpSpeed;
                        anim.SetTrigger("isAir");
                       
                    }
                }
            }

            moveDirection.y -= gravity * Time.deltaTime;

            cc.Move(moveDirection * Time.deltaTime);

            anim.SetFloat("speed", Input.GetAxis("Vertical"));

            curStat = anim.GetCurrentAnimatorStateInfo(0);

            /*if (curStat.IsName("Base Layer.idle"))
            {
                
            }*/


            if (curStat.fullPathHash != idleState)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    anim.SetTrigger("taunt");
                    
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    anim.SetTrigger("atk1");
                    fire();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    anim.SetTrigger("atk2");
                    
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    anim.SetTrigger("special");
                    
                }

                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    isruning = true;
                    anim.SetBool("isRunning", true);
                }
                else if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    isruning = false;
                    anim.SetBool("isRunning", false);
                }
            }
        }
	}


    void fire()
    {
       
            Debug.Log("Pew");

            if (projectile)
            {
                Rigidbody rb = Instantiate(projectile, projectileSpawnPT.position, projectileSpawnPT.rotation) as Rigidbody;

                rb.AddForce(projectileSpawnPT.forward * projectileSpeed, ForceMode.Impulse);
            }
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Finish")
        {
            anim.SetBool("isdead", true);
        }
    }

    public void jumpf()
    {
        
    }
}
