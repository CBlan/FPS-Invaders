using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowQualityToggle : MonoBehaviour {

    private Toggle m_Toggle;
    // Use this for initialization
    void Start () {
        m_Toggle = GetComponent<Toggle>();
        if (QualitySettings.GetQualityLevel() == 1)
        {
            m_Toggle.isOn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
