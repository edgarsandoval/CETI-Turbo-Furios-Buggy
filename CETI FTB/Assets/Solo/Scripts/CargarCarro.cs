using UnityEngine;
using System.Collections;

public class CargarCarro : MonoBehaviour {

	public GameObject Rojo;
	public GameObject Azul;
	public GameObject Amarillo;
	public GameObject Verde;
	public GameObject Blanco;
	public GameObject Rosa;
	public GameObject Morado;
	public GameObject Negro;
	public int kartSelected = 0;

	void awake () {
		//GameObject.DontDestroyOnLoad (this.gameObject);
	}

	void Start ()
	{

		GameObject go = GameObject.Find ("Spawn Player");
		if (go == null)
		{
			go = new GameObject ("Span Player");
		}


		kartSelected =  PlayerPrefs.GetInt ("kart");
		switch(kartSelected)
		{
		case 0:
			Rojo.SetActive(true);
			Azul.SetActive(false);
			Amarillo.SetActive(false);
			Verde.SetActive(false);
			Blanco.SetActive(false);
			Rosa.SetActive(false);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 1:
			Rojo.SetActive(false);
			Azul.SetActive(true);
			Amarillo.SetActive(false);
			Verde.SetActive(false);
			Blanco.SetActive(false);
			Rosa.SetActive(false);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 2:
			Rojo.SetActive(false);
			Azul.SetActive(false);
			Amarillo.SetActive(true);
			Verde.SetActive(false);
			Blanco.SetActive(false);
			Rosa.SetActive(false);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 3:
			Rojo.SetActive(false);
			Azul.SetActive(false);
			Amarillo.SetActive(false);
			Verde.SetActive(true);
			Blanco.SetActive(false);
			Rosa.SetActive(false);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 4:
			Rojo.SetActive(false);
			Azul.SetActive(false);
			Amarillo.SetActive(false);
			Verde.SetActive(false);
			Blanco.SetActive(true);
			Rosa.SetActive(false);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 5:
			Rojo.SetActive(false);
			Azul.SetActive(false);
			Amarillo.SetActive(false);
			Verde.SetActive(false);
			Blanco.SetActive(false);
			Rosa.SetActive(true);
			Morado.SetActive(false);
			Negro.SetActive(false);
			break;
		case 6:
			Rojo.SetActive(false);
			Azul.SetActive(false);
			Amarillo.SetActive(false);
			Verde.SetActive(false);
			Blanco.SetActive(false);
			Rosa.SetActive(false);
			Morado.SetActive(true);
			Negro.SetActive(false);
			break;
		case 7:
			Rojo.SetActive (false);
			Azul.SetActive (false);
			Amarillo.SetActive (false);
			Verde.SetActive (false);
			Blanco.SetActive (false);
			Rosa.SetActive (false);
			Morado.SetActive (false);
			Negro.SetActive (true);
			break;
		}
	}
}
