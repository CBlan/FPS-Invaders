using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour {

    public GameObject bullet;
    public GameObject[] muzzles;
    private GameObject bulletFired;
    public float bulletSpeed;
    public float weaponDamage;

    void OnEnable()
    {
        PlayerInput.Weapon1Fired += WeaponFired;
    }

    void OnDisable()
    {
        PlayerInput.Weapon1Fired -= WeaponFired;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TargetObject.tarObj.target != null)
        {
            for (int i = 0; i < muzzles.Length; i++)
            {
                muzzles[i].transform.LookAt(TargetObject.tarObj.hitPoint);
            }
        }
        else
        {
            for (int i = 0; i < muzzles.Length; i++)
            {
                //print("null");
                muzzles[i].transform.rotation = transform.rotation;
            }
        }
	}

    void WeaponFired()
    {
        //print("Weapon Fired");
        GameObject fireingMuzzle = muzzles[Random.Range(0, muzzles.Length)];
        Instantiate(bullet, fireingMuzzle.transform.position, fireingMuzzle.transform.rotation);
        Fabric.EventManager.Instance.PostEvent("Player/Shoot");
        //bulletFired = Instantiate(bullet, fireingMuzzle.transform.position, fireingMuzzle.transform.rotation);
        //bulletFired.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //bulletFired.GetComponent<BulletBehaviour>().damage = weaponDamage;
    }
}
