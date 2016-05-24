using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MapSelector : MonoBehaviour
{
	public Button primerNivel;
	public Button segundoNivel;
	public Button tercerNivel;

	void Start ()
	{
		segundoNivel.interactable = false;
		tercerNivel.interactable = false;
	}

	public void selecionarMapa(int mapa)
	{
		PlayerPrefs.SetInt ("mapa", mapa);
		Application.LoadLevel ("Mapa");
	}
}
