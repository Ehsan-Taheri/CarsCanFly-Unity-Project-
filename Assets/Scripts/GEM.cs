using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEM : MonoBehaviour
{
    AudioSource ac;
    // Start is called before the first frame update
    void Start()
    { 
       ac=GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0, 5, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "gem")
        ac.Play();
            Destroy(gameObject);
        PlayerPrefs.SetInt("gem", PlayerPrefs.GetInt("gem") + 1);
            print("gem collceted");
        
    }
}
