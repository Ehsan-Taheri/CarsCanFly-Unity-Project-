 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour {
	public float autorotspeed=5f;
	[SerializeField] float rotationspeed=100f;
	bool drag=false;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	void OnMouseDrag(){
		print ("drag is true");
		drag = true;
		

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			drag = false;
			print ("drag is false");
		}
		if (!drag)
			
		transform.Rotate (0, autorotspeed * Time.deltaTime, 0);
	}
	void FixedUpdate(){
		if (drag) {
			print ("draging");
			float x = Input.GetAxis ("Mouse X") * rotationspeed * Time.fixedDeltaTime;
			rb.AddTorque (Vector3.down * x);

		}

	}
}
