using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMouseOption : MonoBehaviour {

    private Slider mainSlider;

    public void Start()
    {
        mainSlider = gameObject.GetComponent<Slider>();
        mainSlider.value = OptionsManager.oMInstance.mouseSen;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
