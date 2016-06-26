using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CargarCarro : MonoBehaviour {

	public GameObject carro;
	public GameObject[] kart;
	public PathManager[] pistasIA;
	public int kartSelected = 0;
	public GameObject[] pistaAux;
	public GameObject colisionador;

	private Vector3 spawnPoint;
	private int mapa;

	private bool couroutineStarted = false;
	private int tiempo = 3;
	private GameObject contador;

	void Start ()
	{
		contador = GameObject.Find ("Canvas").transform.FindChild("Contador").gameObject;
		mapa = 1;//PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;
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
			spawnPosition = new Vector3 (257.9f, 13.80426f, -71.75798f);
			carro.transform.position = spawnPosition;
			carro.transform.rotation = Quaternion.Euler (0, 180, 0);
			spawnPoint = spawnPosition;
			break;
		case 3:
			pistaAux [0].SetActive (true);
			pistaAux [1].SetActive (false);
			spawnPosition = new Vector3 (302.5f, 15.63f, 175.7f);
			carro.transform.position = spawnPosition;
			carro.transform.rotation = Quaternion.Euler (0, 180, 0);
			spawnPoint = spawnPosition;
			break;
		case 4:
			pistaAux [1].SetActive (true);
			pistaAux [0].SetActive (false);
			spawnPosition = new Vector3 (-102.4f, 13.3f, 235.6f);
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
		if (tiempo > 0)
			contador.GetComponent<Text> ().text = tiempo.ToString ();
		if (tiempo == 0)
			contador.GetComponent<Text> ().text = "Corre!";
		if (tiempo == -1) {
			contador.GetComponent<Text> ().text = "";
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
			case 4:
				crearOponente (7);
				break;
			}
			tiempo--;
		}
		contador.SetActive (true);
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

		go.AddComponent<CapsuleCollider> ();
		go.GetComponent<CapsuleCollider> ().center = new Vector3 (0.0f, 0.35f, 0.0f);
		go.GetComponent<CapsuleCollider> ().direction = 2;
		go.GetComponent<CapsuleCollider> ().radius = 0.25f;
		go.GetComponent<CapsuleCollider> ().height = 0.8f;

		go.AddComponent<Rigidbody> ();
		go.GetComponent<Rigidbody> ().mass = 10;
		go.GetComponent<Rigidbody> ().drag = 4;
		go.GetComponent<Rigidbody> ().angularDrag = 6;
		go.GetComponent<Rigidbody> ().useGravity = false;

		//go.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX;
		//go.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationY;

		/*
		GameObject capsula = GameObject.CreatePrimitive(PrimitiveType.Capsule);

		// Set Mesh Filter
		go.AddComponent<MeshFilter> ();
		go.GetComponent<MeshFilter> ().mesh = capsula.GetComponent<MeshFilter> ().mesh;

		// Set Character Collider
		Destroy (capsula);

		go.AddComponent<CharacterController>();
		go.GetComponent<CharacterController> ().radius = 0.3f;
		go.GetComponent<CharacterController> ().height = 1.0f;
		*/

		// Añade script movimiento
		go.AddComponent<hoMove>();
		// Añade tag necesario para vueltas
		go.tag = (mapa == 4) ? "IAFinal" : "IA";
		// Añade script para añadirlo al suelo
		go.AddComponent<SpiderIA> ();
		// Añade una ruta
		go.GetComponent<hoMove> ().setPath (pistasIA[AddRuta()]);

		GameObject oponente = Instantiate (kart[i], spawnPoint, Quaternion.Euler (-90, -89, 0)) as GameObject;
		oponente.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		oponente.SetActive (true);
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
		case 4:
			return Random.Range (8, 11);
			break;
		}
		return 0;
	}
}