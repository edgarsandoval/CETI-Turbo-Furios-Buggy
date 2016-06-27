using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Carreras : MonoBehaviour {
	public int pista = 1;
	public static int vuelta = 0, vueltaIA = 0;
	public GameObject Ganador; 
	public GameObject Perdedor;
	public GameObject Boton;

	void Awake()
	{
		InvokeRepeating ("cambioVelocidad", 4, 1f);
	}

	void Start () {
		pista = PlayerPrefs.GetInt ("mapa");
		vuelta = 0; 
		vueltaIA = 0;
	}
	
	void Update () {
		switch (pista) {
		case 1:
			final (10);
			break;
		case 2:
			final (14);
			break;
		case 3:
			final (18);
			break;
		case 4:
			final (4);
			break;
		}
	}

	public void cambioVelocidad()
	{
		GameObject[] IA = GameObject.FindGameObjectsWithTag ("IA");
		GameObject jugador = GameObject.FindWithTag ("Player");


		jugador.GetComponent<SpiderPlayer>().forwardSpeed = Random.Range (2f, 4f);

		for (int i = 0; i < IA.Length; i++)
			IA[i].GetComponent<hoMove> ().speed = Random.Range(18f, 19f);
	}

	public void final(int vueltas) {
		if (vueltaIA >= vueltas && vuelta < 4)
			perdio ();
		else if (vuelta == 4 && vueltaIA < vueltas)
			gano ();
	}

	public void gano() {
		Time.timeScale = 0;
		AudioListener.volume = 0;
		PlayerPrefs.SetInt ("progreso", pista);
		Ganador.SetActive (true);
		Boton.SetActive (true);
	}

	public void perdio() {
		Time.timeScale = 0;
		AudioListener.volume = 0;
		Perdedor.SetActive (true);
		Boton.SetActive (true);
	}

	public void Continuar() {
		Application.LoadLevel ("SelectorMapa");
		Ganador.SetActive (false);
		Perdedor.SetActive (false);
		Boton.SetActive (false);
		Time.timeScale = 1;
		AudioListener.volume = 1;
	}
}
