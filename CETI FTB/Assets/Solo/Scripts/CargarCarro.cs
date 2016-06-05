using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CargarCarro : MonoBehaviour {

	public GameObject carro;
	public GameObject[] kart;
	public PathManager[] pistasIA;
	public int kartSelected = 0;

	private Vector3 spawnPoint;
	private int mapa;

	private bool couroutineStarted = false;
	private int tiempo = 3;
	private GameObject contador;

	void Start ()
	{
		contador = GameObject.Find ("Canvas").transform.FindChild("Contador").gameObject;
		mapa = PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;
		kartSelected =  PlayerPrefs.HasKey ("kart") ? PlayerPrefs.GetInt ("kart") : 1;

		for (int i = 0; i < kart.Length; i++)
			kart [i].SetActive (false);
		kart [kartSelected].SetActive (true);

		Vector3 spawnPosition;
		switch (mapa) {
		case 1:
			spawnPosition = new Vector3 (50.64661f, 4.401484f, 11.26688f);
			carro.transform.position = spawnPosition;
			carro.transform.rotation = Quaternion.Euler (0, 190, 0);
			spawnPoint = spawnPosition;
			break;
		case 2:
			spawnPosition = new Vector3 (267.274f, 13.80426f, -71.75798f);
			carro.transform.position = spawnPosition;
			carro.transform.rotation = Quaternion.Euler (0, 180, 0);
			spawnPoint = spawnPosition;
			break;
		case 3:
			spawnPosition = new Vector3 (310f, 19.6f, 175.7f);
			carro.transform.position = spawnPosition;
			carro.transform.rotation = Quaternion.Euler (0, 180, 0);
			spawnPoint = spawnPosition;
			break;
		}

		// Detiene al jugador
		carro.GetComponent<SpiderPlayer>().enabled = false;

		contador.SetActive (true);
	}

	void Update()
	{
		if (!couroutineStarted)
			StartCoroutine (retardo (1));

		contador.GetComponent<Text> ().text = tiempo > 0 ? tiempo.ToString() : "Corre!";

		if (tiempo == -1) {
			contador.SetActive (false);
			carro.GetComponent<SpiderPlayer>().enabled = true;
			switch (mapa) {
			case 1:
				for (int i = 0; i < 3; i++)
					crearOponente (i);	
				break;
			case 2:
				for (int i = 0; i < 5; i++)
					crearOponente (i);
				break;
			case 3:
				for (int i = 0; i < 7; i++)
					crearOponente (i);
				break;
			}
			tiempo--;
		}
	}

	IEnumerator retardo(float t)
	{
		couroutineStarted = true;
		yield return new WaitForSeconds(t);
		tiempo--;
		couroutineStarted = tiempo == -1;
	}

	public void crearOponente(int i)
	{
		if (i % 2 == 0)
			spawnPoint.x -= 10;
		else
		{
			spawnPoint.x += 10;
			spawnPoint.z += 10;
		}

		GameObject go = new GameObject ("Oponente " + i);
		go.transform.position = spawnPoint;
		go.transform.rotation = carro.transform.rotation;
		go.transform.localScale = carro.transform.localScale;

		GameObject capsula = GameObject.CreatePrimitive(PrimitiveType.Capsule);

		// Set Mesh Filter
		go.AddComponent<MeshFilter> ();
		go.GetComponent<MeshFilter> ().mesh = capsula.GetComponent<MeshFilter> ().mesh;

		// Set Character Collider
		go.AddComponent<CharacterController>();
		Destroy (capsula);

		// Añade script movimiento
		go.AddComponent<hoMove>();
		// Añade tag necesario para vueltas
		go.tag = "IA";
		// Añade script para añadirlo al suelo
		go.AddComponent<SpiderIA> ();
		// Añade una ruta
		go.GetComponent<hoMove> ().setPath (pistasIA[AddRuta()]);

		GameObject oponente = Instantiate (kart[i], spawnPoint, Quaternion.Euler (-90, -80, 0)) as GameObject;
		oponente.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		oponente.SetActive (true);
		//oponente.AddComponent<MeshCollider> ();
		oponente.transform.parent = go.transform;
	}

	private int AddRuta() {
		switch (mapa) {
		case 1:
			return Random.Range (0, 2);
			break;
		case 2:
			return Random.Range (2, 5);
			break;
		case 3:
			return Random.Range (5, 8);
			break;
		}
		return 0;
	}
}