using UnityEngine;
using System.Collections;

public class CargarCarro : MonoBehaviour {

	public GameObject carro;
	public GameObject[] kart;
	public int kartSelected = 0;

	private Vector3 spawnPoint;
	private int mapa;

	void Start ()
	{
		mapa = PlayerPrefs.HasKey ("mapa") ? PlayerPrefs.GetInt ("mapa") : 1;
		kartSelected =  PlayerPrefs.HasKey ("kart") ? PlayerPrefs.GetInt ("kart") : 1;
		for (int i = 0; i < kart.Length; i++)
			kart [i].SetActive (false);
		kart [kartSelected].SetActive (true);
		switch (mapa)
		{
			case 1:
			{
				Vector3 spawnPosition = new Vector3 (50.64661f, 4.401484f, 11.26688f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 190, 0);

				spawnPoint = spawnPosition;
				for (int i = 0; i < 3; i++)
					crearOponente (i);
				break;
			}
			case 2:
			{
				Vector3 spawnPosition = new Vector3 (267.274f, 13.80426f, -71.75798f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 180, 0);

				spawnPoint = spawnPosition;

				for (int i = 0; i < 5; i++)
					crearOponente (i);
				break;
			}
		case 3:
			{
				Vector3 spawnPosition = new Vector3 (310f, 19.6f, 175.7f);
				carro.transform.position = spawnPosition;
				carro.transform.rotation = Quaternion.Euler (0, 180, 0);

				spawnPoint = spawnPosition;
				for (int i = 0; i < 7; i++)
					crearOponente (i);
				break;
			}
		}
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

		// Set Capsule Collider
		go.AddComponent<CapsuleCollider>();
		go.GetComponent<CapsuleCollider>().center = new Vector3 (0f, 0.6f, -0.1f);
		go.GetComponent<CapsuleCollider> ().radius = 0.28f;
		go.GetComponent<CapsuleCollider> ().height = 1;
		go.GetComponent<CapsuleCollider> ().direction = 2;

		// Set Rigidbody
		go.AddComponent<Rigidbody>();
		go.GetComponent<Rigidbody> ().mass = 10;
		go.GetComponent<Rigidbody> ().drag = 4;
		go.GetComponent<Rigidbody> ().angularDrag = 6;
		go.GetComponent<Rigidbody> ().useGravity = false;
		go.GetComponent<Rigidbody> ().isKinematic = false;
		go.GetComponent<Rigidbody> ().collisionDetectionMode = CollisionDetectionMode.Discrete;

		// Add Spider Player.js w/values
		CopyComponent (carro.GetComponent("SpiderPlayer"), go);

		Destroy (capsula);

		GameObject oponente = Instantiate (kart[i], spawnPoint, Quaternion.Euler (-90, -80, 0)) as GameObject;
		oponente.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		oponente.SetActive (true);

		oponente.transform.parent = go.transform;
	}

	public Component CopyComponent(Component original, GameObject destino)
	{
		System.Type tipo = original.GetType();
		Component copia = destino.AddComponent(tipo);

		System.Reflection.FieldInfo[] campos = tipo.GetFields();

		foreach (System.Reflection.FieldInfo campo in campos)
		{
			campo.SetValue (copia, campo.GetValue (original));
		}	

		return copia;
	}
}