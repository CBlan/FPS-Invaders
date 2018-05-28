using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderExplosionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Exploder/Explosion", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
