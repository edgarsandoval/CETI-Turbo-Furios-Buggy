public var direction:Vector3;

function OnTriggerStay (collider:Collider) {
	Debug.Log("hey0");
	if (collider.tag == 'Player') {
		Debug.Log("hey");
		collider.GetComponent.<Rigidbody>().AddForce(direction, ForceMode.Acceleration);
	}
}