using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Menu/Loading", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
