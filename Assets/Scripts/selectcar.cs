using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectcar : MonoBehaviour {
	
	int cur_car,prev_car;
	public Transform cars;
	public Button perv, next;
	AudioSource ac ;
	public AudioClip change,  select;
	// Use this for initialization
	void Start () {
		cur_car = PlayerPrefs.GetInt ("carindx");
		cars.GetChild (cur_car).gameObject.SetActive (true);
		ac = GetComponent<AudioSource>();
		
		 
	}
	
	public void nextcar(int indx){
		 
        

        ac.clip = change;
		ac.Play();
		cars.GetChild (cur_car).gameObject.SetActive (false);
        prev_car = cur_car;
        cur_car += indx;
        if (cur_car > cars.childCount)
			cur_car = 0;

		else if (cur_car <0)
			cur_car = cars.childCount-1;
		
			
        cars.GetChild (cur_car).rotation = cars.GetChild (prev_car).rotation;

		

		cars.GetChild (cur_car).gameObject.SetActive (true);
		 
	}
	public void selecting(){
		ac.clip = select;
		ac.Play();
		PlayerPrefs.SetInt ("carindx",cur_car);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("main");

	}
	void autcar(){
		if (cur_car == 0)
			perv.gameObject.SetActive(false);
		else
			perv.gameObject.SetActive(true);
		if (cur_car == cars.childCount-1)
			next.gameObject.SetActive(false);
		else
			next.gameObject.SetActive(true);
	}
}
