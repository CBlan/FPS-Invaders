using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonExplosionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Pylon/Destroy", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
