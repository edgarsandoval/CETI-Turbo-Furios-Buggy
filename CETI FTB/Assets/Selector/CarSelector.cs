using UnityEngine;
using System.Collections;

public class CarSelector : MonoBehaviour
{
	public GameObject Rojo;
	public GameObject Azul;
	public GameObject Amarillo;
	public GameObject Verde;
	public GameObject Blanco;
	public GameObject Rosa;
	public GameObject Morado;
	public GameObject Negro;
	public int kartSelected = 0; 

	public void Seleccionar() {
		PlayerPrefs.SetInt ("kart", kartSelected);
		Application.LoadLevel("Mapa");
	}

	public void Regresar() {
		Application.LoadLevel("Menu");
	}

	void start()
	{
		
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

	public void next()
	{
		kartSelected++;
		if (kartSelected == 8)
			kartSelected = 0;
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

	public void prev()
	{
		kartSelected--;
		if (kartSelected == -1)
			kartSelected = 7;
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