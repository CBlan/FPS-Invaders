using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour {


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
		
	}

    void WeaponFired()
    {
        print("Weapon Fired");
    }
}
