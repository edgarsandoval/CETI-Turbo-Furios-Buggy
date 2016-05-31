using UnityEngine;
using System.Collections;

public class CargarMapa : MonoBehaviour {

	//public GameObject carro;

	private int mapa;

	void Start ()
	{
		//kartSelected = PlayerPrefs.HasKey ("kart") ? PlayerPrefs.GetInt ("kart") : 0;	
		mapa = PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;

		/*switch (mapa) {
		case 1:
			{
				Vector3 spawnPosition = new Vector3 (50.64661f, 4.401484f, 11.26688f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 190, 0);
				break;
			}
		case 2:
			{
				Vector3 spawnPosition = new Vector3 (267.274f, 13.80426f, -71.75798f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 180, 0);

				break;
			}
		case 3:
			{
				Vector3 spawnPosition = new Vector3 (310f, 19.6f, 175.7f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 180, 0);

				break;
			}
		}*/
	}
}
