﻿using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour 
{
	public  bool Shaking;
	private float ShakeDecay;
	private float ShakeIntensity;
	public float si=0.1f;
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;

	void Start()
	{
		Shaking = false;    
	}


	// Update is called once per frame
	void Update () 
	{
		 
		if(ShakeIntensity > 0)
		{
				//transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
				transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
				OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);

			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;    
		}
	}

	public void DoShake ()
	{
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
		ShakeIntensity = si;
	 
		ShakeDecay = 0.02f;
		Shaking = true;
	}
}