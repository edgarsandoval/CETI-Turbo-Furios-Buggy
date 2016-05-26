using UnityEngine;
using System.Collections;

public class Carreras : MonoBehaviour {
	public int pista = 1;
	public int posicion;
	public static int vuelta = 0;
	public GameObject texto;

	void Start () {
		pista = PlayerPrefs.GetInt ("mapa");	
	}
	
	void Update (){
		if (vuelta == 3)
			gano ();
	}

	public void gano()
	{
		if (posicion == 1 && vuelta == 3) {
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
		}
		Application.LoadLevel ("SelectorMapa");
	}
		
}
