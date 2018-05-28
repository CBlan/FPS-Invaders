using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShipExplosionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("DropShip/Explosion", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
