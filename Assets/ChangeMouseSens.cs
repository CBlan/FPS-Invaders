using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMouseSens : MonoBehaviour
{

    private Slider mainSlider;
    public MouseLook mouseLook;

    public void Start()
    {
        mainSlider = gameObject.GetComponent<Slider>();
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        //Debug.Log(mainSlider.value);
        mouseLook.mouseSensitivity = mainSlider.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
