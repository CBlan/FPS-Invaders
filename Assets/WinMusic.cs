using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent("Menu/Win", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
