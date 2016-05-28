using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MapSelector : MonoBehaviour
{
	public Button primerNivel;
	public Button segundoNivel;
	public Button tercerNivel;
	public InputField txtNombre;
	private int mapas = 1;

	void Start ()
	{
		segundoNivel.interactable = false;
		tercerNivel.interactable = false;
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
		}
	}

	public void selecionarMapa(int mapa)
	{
		PlayerPrefs.SetInt ("mapa", mapa);
		Application.LoadLevel ("Mapa");
	}
}
