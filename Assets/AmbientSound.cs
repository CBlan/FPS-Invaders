using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Enviro/Music", gameObject);
        Fabric.EventManager.Instance.PostEvent("Enviro/Wind1", gameObject);
        Fabric.EventManager.Instance.PostEvent("Enviro/Wind2", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
