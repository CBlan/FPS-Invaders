using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Menu/Loss", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
