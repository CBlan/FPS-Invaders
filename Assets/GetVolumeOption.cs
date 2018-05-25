using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVolumeOption : MonoBehaviour {

    private Slider mainSlider;

    public void Start()
    {
        mainSlider = gameObject.GetComponent<Slider>();
        mainSlider.value = OptionsManager.oMInstance.volume;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
