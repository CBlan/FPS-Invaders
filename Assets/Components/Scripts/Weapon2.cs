using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{


    void OnEnable()
    {
        PlayerInput.Weapon2Fired += WeaponFired;
    }

    void OnDisable()
    {
        PlayerInput.Weapon2Fired -= WeaponFired;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void WeaponFired()
    {
        print("Weapon 2 Fired");
    }
}