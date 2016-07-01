using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Carreras : MonoBehaviour {
	private int pista;
	public static int vuelta = 0, vueltaIA = 0;
	public GameObject Ganador; 
	public GameObject Perdedor;
	public GameObject Boton;

	void Awake() {
		InvokeRepeating ("cambioVelocidad", 4, 1f);
	}

	void Start () {
		pista = PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;
		vuelta = 0; 
		vueltaIA = 0;
	}
	
	void Update () {
		switch (pista) {
		case 1:	
			final ((3*3)+1);
			break;
		case 2:
			final ((3*5)+1);
			break;
		case 3:
			final ((3*7)+1);
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
		jugador.GetComponent<SpiderPlayer>().forwardSpeed = Random.Range (2f, 2.5f);
		for (int i = 0; i < IA.Length; i++)
			IA[i].GetComponent<hoMove> ().speed = Random.Range(17f, 19f);
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

	public void regresar()
	{
		PlayerPrefs.SetString ("nextScene", "MapaMultijugador");
		Application.LoadLevel ("Transicion");
	}
}
