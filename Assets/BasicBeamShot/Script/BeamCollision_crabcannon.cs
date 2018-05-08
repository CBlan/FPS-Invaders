using UnityEngine;
using System.Collections;

public class BeamCollision_crabcannon : MonoBehaviour {
	
    public bool Reflect = false;
	private BeamLine_crabcannon BL;
    public float hitDamage;

	public GameObject HitEffect = null;

	private bool bHit = false;

	private BeamParam_crabcannon BP;

	// Use this for initialization
	void Start () {
		BL = (BeamLine_crabcannon)this.gameObject.transform.Find("BeamLine_crabcannon").GetComponent<BeamLine_crabcannon>();
		BP = this.transform.root.gameObject.GetComponent<BeamParam_crabcannon>();
	}
	
	// Update is called once per frame
	void Update () {
		//RayCollision
		RaycastHit hit;
        int layerMask = ~(1 << LayerMask.NameToLayer("NoBeamHit") | 1 << 2);
        if (HitEffect != null && !bHit && Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            GameObject hitobj = hit.collider.gameObject;
			if(hit.distance < BL.GetNowLength())
		    {
				BL.StopLength(hit.distance);
				bHit = true;

                Quaternion Angle;
                //Reflect to Normal
                if (Reflect)
                {
                    Angle = Quaternion.LookRotation(Vector3.Reflect(transform.forward, hit.normal));
                }
                else
                {
                    Angle = Quaternion.AngleAxis(180.0f, transform.up) * this.transform.rotation;
                }

                if (hitobj.tag == "Enemy")
                {
                    hitobj.transform.root.gameObject.GetComponent<Health>().hP -= hitDamage;
                }

                GameObject obj = (GameObject)Instantiate(HitEffect,this.transform.position+this.transform.forward*hit.distance,Angle);
				obj.GetComponent<BeamParam_crabcannon>().SetBeamParam(BP);
				obj.transform.localScale = this.transform.localScale;
			}
			//print("find" + hit.collider.gameObject.name);
		}
		/*
		if(bHit && BL != null)
		{
			BL.gameObject.renderer.material.SetFloat("_BeamLength",HitTimeLength / BL.GetNextLength() + 0.05f);
		}
		*/
	}
}
