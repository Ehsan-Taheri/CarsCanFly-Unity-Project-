using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope : MonoBehaviour {
	public RectTransform su,sd;
	public static bool isScope;
	float U,D;
	// Use this for initialization
	void Start(){
		U = su.localPosition.y - su.rect.height;
		D = sd.localPosition.y + sd.rect.height;
	 
	
	}
	Vector3 u,d;
	// Update is called once per frame
	void Update () {
		if ( isScope) {
			 
			if (su.localPosition.y > U+5) {
				u = su.localPosition;
				u.y -= 8f;
				 
				su.localPosition = u;
			}
			if (  sd.localPosition.y <D-5 ){
				d = sd.localPosition;
				d.y += 8f;
			 
				sd.localPosition = d;
			}
		}
	}
}
