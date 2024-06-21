using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
	public Transform road;
	public float size;
 
	// Use this for initialization
	void Start () {
		
		 
	 
		InvokeRepeating ("roading", 10f, 5f);
	}
	
	void	roading (){
		road.GetChild (0).position = new Vector3 (0, road.GetChild (road.childCount - 1).position.y, road.GetChild (road.childCount - 1).position.z + size);
		road.GetChild (0).SetAsLastSibling ();

	}

}
