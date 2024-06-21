using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ac;
    public AudioSource aso;

    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        aso.clip =ac;
        aso.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
