using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Has Exceptions

public class ExceptionTester : MonoBehaviour {

    //projectile pro;
    guns gunner;

	// Use this for initialization
	void Start () {
       // pro = GetComponent<projectile>();
        gunner = GetComponent<guns>();
        try
        {
            if(gunner.proFireRate > 5f)
                throw new ArgumentNullException("Fire Rate error");
            // if(!pro)
            //   throw new ArgumentNullException("no projectile detected");
        }
        catch (ArgumentNullException e)
        {
            Debug.Log(e.Message);
        }
        /*finally
        {
            // if nothing was called
            Debug.Log("Stuff Broke");
        }*/
        try
        {
            if (gunner.projectileSpeed > 61f)
                throw new ArgumentNullException("Projectile Speed Error");
        }
        catch (ArgumentNullException e)
        {
            Debug.Log(e.Message);
        }
        /*finally
        {
            // if nothing was called
            Debug.Log("Stuff Broke");
        }*/
    }
}
