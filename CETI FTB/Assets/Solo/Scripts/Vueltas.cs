using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vueltas : MonoBehaviour {
	public Text txt;

	void Start () {
		txt.text = "Vuelta: 0";
	}

	void Update () {
		txt.text = "Vuelta: " + Carreras.vuelta;
	}
}
