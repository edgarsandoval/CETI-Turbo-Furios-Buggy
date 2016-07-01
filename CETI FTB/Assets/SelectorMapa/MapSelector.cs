using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MapSelector : MonoBehaviour
{
	public Button primerNivel;
	public Button segundoNivel;
	public Button tercerNivel;
	public Button nivelFinal;
	private int mapas = 0;

	void Start ()
	{
		segundoNivel.interactable = false;
		tercerNivel.interactable = false;
		nivelFinal.interactable = false;
		if (PlayerPrefs.HasKey ("progreso"))
			mapas = PlayerPrefs.GetInt ("progreso");
		switch (mapas) {
		case 1:
			segundoNivel.interactable = true;
			break;
		case 2:
			segundoNivel.interactable = true;
			tercerNivel.interactable = true;
			break;
		case 3:
		case 4:
			segundoNivel.interactable = true;
			tercerNivel.interactable = true;
			nivelFinal.interactable = true;
			break;
		}
	}

	public void selecionarMapa(int mapa) {
		PlayerPrefs.SetInt ("mapa", mapa);
		PlayerPrefs.SetString ("nextScene", "Mapa");
		Application.LoadLevel ("Transicion");
	}

	public void regresarMenu()
	{
		Application.LoadLevel ("menu");
	}
}
