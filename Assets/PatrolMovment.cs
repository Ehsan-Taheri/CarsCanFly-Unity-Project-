using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovment : MonoBehaviour
{
     float speed = 5f;
    float distance;
    Vector3 Place2;
     Vector3 destinition,Place1;
    // Start is called before the first frame update
    void Start()
    {
        distance = Random.Range(10, 50);
        speed = Random.Range(3, 5);
        Place1 = transform.position;
        Place2 = new Vector3(Place1.x + distance, Place1.y, Place1.z);
        destinition = Place2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destinition) < 0.1f)
        {
            destinition = Place1;
        }
        if (Vector3.Distance(transform.position, destinition) < 0.1f)
        {
            destinition = Place2;
        }
     transform.position=  Vector3.MoveTowards(transform.position, destinition, speed * Time.deltaTime);

    }
}
