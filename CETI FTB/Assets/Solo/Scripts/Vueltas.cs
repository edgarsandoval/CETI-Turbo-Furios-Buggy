using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vueltas : MonoBehaviour {
	public Text txt;

	void Start () {
		txt = GetComponent<Text> ();
		txt.text = "Vuelta: 1";
	}

	void Update () {
		txt.text = "Vuelta: " + Carreras.vuelta;
	}
}
