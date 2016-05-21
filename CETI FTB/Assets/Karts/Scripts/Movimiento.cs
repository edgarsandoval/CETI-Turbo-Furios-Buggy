using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public WheelCollider Llanta1;	//Llanta trasera
	public WheelCollider Llanta2;	//Llanta trasera
	public WheelCollider Llanta3;	//Llanta delantera
	public WheelCollider Llanta4;	//Llanta delantera
	public int velocidad = 150;

	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.centerOfMass = new Vector3 (0, -1f, 0);
	}	

	void FixedUpdate () {
		Llanta1.motorTorque = velocidad * Input.GetAxis ("Vertical");
		Llanta2.motorTorque = velocidad * Input.GetAxis ("Vertical");
		//Rotar llantas delanteras
		Llanta3.steerAngle = 10 * Input.GetAxis ("Horizontal");
		Llanta4.steerAngle = 10 * Input.GetAxis ("Horizontal");
	}
}
