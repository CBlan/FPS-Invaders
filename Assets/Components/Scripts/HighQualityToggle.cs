using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighQualityToggle : MonoBehaviour {

    private Toggle m_Toggle;
    // Use this for initialization
    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        if (QualitySettings.GetQualityLevel() == 2)
        {
            m_Toggle.isOn = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
