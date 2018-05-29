using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Menu/Start", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
