
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{

    public GameObject cameraTarget;
    public float sSpeed = 10.0f;
    public Vector3 dist;
    public Transform jumpTarget;
    Vector3 startcam;
    Quaternion startroot;
    public static bool rot, norot;
    bool last; Vector3 lpos;
    void Start()
    {
        set_target();

    }
    void FixedUpdate()
    {


        if (rot)
        {

            Vector3 dPos = jumpTarget.position + dist;


            

            transform.position = Vector3.Slerp(transform.position, new Vector3(0, dPos.y-2f, dPos.z + 7f), sSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.03f);
        }

        else if (!rot)
        {

            Vector3 dPos = cameraTarget.transform.position + dist;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.fixedDeltaTime);
            //transform.rotation = startroot;

            transform.position = dPos;
        }

    }

    public void set_target()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player");
        jumpTarget = GameObject.Find("cam").transform;
        startcam = transform.position;
        startroot = transform.rotation;
    }
}