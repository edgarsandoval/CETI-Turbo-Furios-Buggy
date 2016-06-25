using UnityEngine;
using System.Collections;

public class MetaIA : MonoBehaviour {

	public int mapa;
	public PathManager[] pistasIA;

	void Awake () {
		this.gameObject.SetActive (true);
	}

	void Start () {
		mapa = PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;
	}

	void OnTriggerEnter (Collider Check) {
		if (Check.tag == "IA" || Check.tag == "IAFinal") {
			Carreras.vueltaIA++;
		}
		if (Check.tag == "IAFinal") {
			GameObject oponente = GameObject.FindGameObjectWithTag ("IAFinal");
			oponente.GetComponent<hoMove> ().setPath (pistasIA[Random.Range (0, 3)]);
		}
	}
}