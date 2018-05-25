using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    private static bool created = false;

    public static OptionsManager oMInstance;
    public float mouseSen;
    public float volume;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            //Debug.Log("Awake: " + this.gameObject);
        }


        if (oMInstance == null)
        {
            oMInstance = this;
        }

        if (oMInstance != this)
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        QualitySettings.SetQualityLevel(5, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(5, true);
    }

    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(3, true);
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(1, true);
    }
}
