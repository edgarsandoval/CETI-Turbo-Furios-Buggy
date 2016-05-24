using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CarSelector : MonoBehaviour
{
	public GameObject[] kart;
	public int kartSelected = 0; 
	public string nombre;
	private InputField txtNombre;

	void Start()
	{
		if (PlayerPrefs.HasKey("kart"))
			kartSelected =  PlayerPrefs.GetInt ("kart");

		showSelectedKart ();
	}

	public void showSelectedKart()
	{
		for (int i = 0; i < kart.Length; i++)
			if (i == kartSelected)
				kart [i].SetActive (true);
			else
				kart [i].SetActive (false);
	}

	public void Seleccionar()
	{
		PlayerPrefs.SetInt ("kart", kartSelected);
		Application.LoadLevel("Menu");
	}

	public void Regresar()
	{
		Application.LoadLevel("Menu");
	}

	public void next()
	{
		kartSelected = (kartSelected + 1 + kart.Length) % kart.Length;
		showSelectedKart ();
	}

	public void prev()
	{
		kartSelected = (kartSelected - 1 + kart.Length) % kart.Length;
		showSelectedKart ();
	}

	public void guardarNombre(string s)
	{
		Debug.Log (s);
	}
}