using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonHumSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Pylon/Hum", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
