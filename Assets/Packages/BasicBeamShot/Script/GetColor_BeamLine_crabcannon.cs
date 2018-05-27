using UnityEngine;
using System.Collections;

public class GetColor_BeamLine_crabcannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BeamParam_crabcannon Parent = this.transform.root.gameObject.GetComponent<BeamParam_crabcannon>();
		if(Parent == null) return;
		BeamLine_crabcannon BL = this.gameObject.GetComponent<BeamLine_crabcannon>();
		BL.BeamColor = Parent.BeamColor;
		
		BL.StartSize = Parent.Scale*0.5f;
		BL.AnimationSpd = Parent.AnimationSpd;
		BL.MaxLength = Parent.MaxLength;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
