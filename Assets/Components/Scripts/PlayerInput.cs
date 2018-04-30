using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float stepSpeed = 10;
    public Transform targetPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //input point to move to
        if (Input.GetButton("Fire3") && TargetObject.tarObj.target != null && TargetObject.tarObj.target.tag == "Defense Point")
        {
            targetPoint = TargetObject.tarObj.target.transform;
        }

        //move to point
        if (targetPoint != null)
        {
            float step = stepSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
            if (transform.position == targetPoint.position)
            {
                targetPoint = null;
            }
        }

        //check if moving to new point before doing anything
        if (targetPoint == null)
        {

        }


    }
}

