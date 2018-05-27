using UnityEngine;
using System.Collections;

public class GetColor_Particle_crabcannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();
		ps.startColor = this.transform.root.gameObject.GetComponent<BeamParam_crabcannon>().BeamColor;
		ps.startSize *= this.transform.root.gameObject.GetComponent<BeamParam_crabcannon>().Scale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
