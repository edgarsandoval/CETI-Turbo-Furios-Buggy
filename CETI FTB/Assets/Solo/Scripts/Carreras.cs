using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Carreras : MonoBehaviour {
	public int pista = 1;
	public int posicion;
	public static int vuelta = 0;
	public Text Ganador; 
	public Text Perdedor;

	void Start () {
		pista = PlayerPrefs.GetInt ("mapa");
	}
	
	void Update (){
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
			Ganador.enabled = true;
			timer (5); //Corregir ¬¬
			vuelta = 0;
			Application.LoadLevel ("SelectorMapa");
		} else {
			Perdedor.text = "Quedaste en " + posicion + " lugar";
			Perdedor.enabled = true;
			Application.LoadLevel ("SelectorMapa");
		}
	}

	private IEnumerator timer(int tiempo) {
		yield return new WaitForSeconds (tiempo);
	}
}
