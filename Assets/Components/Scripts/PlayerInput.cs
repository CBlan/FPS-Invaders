﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float stepSpeed = 10;
    private GameObject targetPoint;
    public GameObject currentPoint;
    private Vector3 midPoint;
    private Vector3 startPoint;
    private bool hasPassedMid = false;
    private float zoomAmmount = 60f;

    public delegate void Weapon1Fire();
    public static event Weapon1Fire Weapon1Fired;

    public delegate void Weapon2Fire();
    public static event Weapon2Fire Weapon2Fired;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //input point to move to
        if (Input.GetButton("Fire3") && TargetObject.tarObj.target != null && TargetObject.tarObj.target.tag == "Defence Point")
        {
            targetPoint = TargetObject.tarObj.target;

            midPoint = (transform.position + TargetObject.tarObj.target.gameObject.transform.position) / 2;
            startPoint = transform.position;

            if (currentPoint != null)
            {
                currentPoint.SetActive(true);
            }
        }

        //move to point
        if (targetPoint != null)
        {
            float step = stepSpeed * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.transform.position, step);

            if (!hasPassedMid)
            {
                Camera.main.fieldOfView -= zoomAmmount * Time.deltaTime;
                if (!IsBetween(startPoint, midPoint, transform.position))
                {

                    hasPassedMid = true;
                }
            }
            else Camera.main.fieldOfView += zoomAmmount * Time.deltaTime;



            if (transform.position == targetPoint.transform.position)
            {
                Camera.main.fieldOfView = 60;
                targetPoint = null;
                hasPassedMid = false;
            }
        }

        //check if moving to new point before doing anything
        if (targetPoint == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Weapon1Fired != null)
                {
                    Weapon1Fired();
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                if (Weapon2Fired != null)
                {
                    Weapon2Fired();
                }
            }
        }

    }

    //turn off graphic for point the camera is on
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Defence Point")
        {
            currentPoint = other.gameObject;
            other.gameObject.SetActive(false);
        }
    }

    bool IsBetween(Vector3 start, Vector3 end, Vector3 objPosition)
    {
        return Vector3.Dot((end - start).normalized, (objPosition - end).normalized) < 0f && Vector3.Dot((start - end).normalized, (objPosition - start).normalized) < 0f;
    }
}

