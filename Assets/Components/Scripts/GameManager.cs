using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;
    public List<GameObject> defensePoints;

    public List<GameObject> portals;

    // Use this for initialization
    void Start () {
        GM = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
