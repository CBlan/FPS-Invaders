using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour {

	void Start ()
    {
        //if(SceneManager.GetActiveScene().isLoaded)
        //    Fabric.EventManager.Instance.PostEvent("Menu/Start", gameObject);
        StartCoroutine("StartMusicLate");
    }
	
	void Update () {
		
	}

    IEnumerator StartMusicLate()
    {
        yield return new WaitForSeconds(0.2f);
        if (SceneManager.GetActiveScene().isLoaded)
        {
            Fabric.EventManager.Instance.PostEvent("Menu/Start", gameObject);
        }
        else StartCoroutine("StartMusicLate");
        yield break;
    }
}
