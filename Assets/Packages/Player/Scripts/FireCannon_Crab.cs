using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon_Crab : MonoBehaviour
{

    public Transform muzzle;
    public GameObject projectile;
    private float cooldown;
    public float bulletInterval;
    private bool fireCannon;
    public float cannonHeat;

    void OnEnable()
    {
        //PlayerController.CannonPressed += FireCannon;
        //PlayerController.CannonReleased += StopCannon;
    }


    void OnDisable()
    {
        //PlayerController.CannonPressed -= FireCannon;
        //PlayerController.CannonReleased -= StopCannon;
    }


    void FireCannon()
    {
        //if (MissionManager.mM.cannonHeat < 100)
        //{
           // fireCannon = true;
        //}
    }

    void StopCannon()
    {
        fireCannon = false;
    }

    private void Update()
    {
        if (fireCannon)
        {
            if (Time.time >= cooldown)
            {
                Instantiate(projectile, muzzle);
                //MissionManager.mM.cannonHeat += cannonHeat;
                //print("Fireing at " + target.transform.name);
                cooldown = bulletInterval + Time.time;
            }
        }
    }

}
