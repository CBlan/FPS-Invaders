using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion_Shake : MonoBehaviour {

    public bool shakeEnabled = true;
    public float shake = 0f;
    public float shakeAmount = 0.5f;
    float decreaseFactor = 1.0f;
    private Vector3 originalPos;
 
    void Update()
    {
        if(enabled)
        {

            if (shake > 0)
            {
                transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
                shake -= Time.deltaTime * decreaseFactor;
            }
            else if (shake < 0)
            {
                shake = 0f;
                transform.position = originalPos;
            }
        }
    }

    public void Shake(float magnitude, float time)
    {
        shakeAmount = magnitude;
        shake = time;
        originalPos = transform.position;
    }
}