using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Poder : MonoBehaviour {
	public Text txt;

	void Start () {
	}

	void Update () {
		switch (Trigger.actual) {
		case 0:
			txt.text = "";
			break;
		case 1:
			txt.text = "Micro";
			break;
		case 2:
			txt.text = "HDD";
			break;
		case 3:
			txt.text = "Sancho";
			break;
		case 4:
			txt.text = "Aifon";
			break;
		}
	}
}
