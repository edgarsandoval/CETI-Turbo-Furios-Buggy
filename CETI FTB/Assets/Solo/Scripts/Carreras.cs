using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Carreras : MonoBehaviour {
	public int pista = 1;
	public int posicion;
	public static int vuelta = 0;
	public GameObject Ganador; 
	public GameObject Perdedor;
	public GameObject Boton;

	void Start () {
		pista = PlayerPrefs.GetInt ("mapa");
	}
	
	void Update () {
		if (vuelta == 3)
			gano ();
	}

	public void gano()
	{
		if (posicion == 1) {
			switch (pista) {
			case 1:
				PlayerPrefs.SetInt ("progreso", 1);
				break;
			case 2:
				PlayerPrefs.SetInt ("progreso", 2);
				break;
			case 3:
				PlayerPrefs.SetInt ("progreso", 3);
				break;
			}
			Ganador.SetActive (true);
			vuelta = 0;
		} else {
			Text txt = Perdedor.GetComponent<Text> ();
			txt.text = "Quedaste en " + posicion + " lugar";
			Perdedor.SetActive (true);
		}
		Boton.SetActive (true);
	}

	public void Continuar() {
		Application.LoadLevel ("SelectorMapa");
	}
}
