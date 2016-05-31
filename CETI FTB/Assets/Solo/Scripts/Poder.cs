using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Poder : MonoBehaviour {
	public Text txt;

	void Start () {
	}

	void Update () {
		txt.text = Trigger.getActual ();
	}
}
