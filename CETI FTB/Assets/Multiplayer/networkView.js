#pragma strict

private var couroutineStarted = false;
private var tiempo = 3;

function Awake()
{
	if (!GetComponent.<NetworkView>().isMine)
	{
   		GetComponentInChildren(Camera).enabled = false;
   		GetComponent(playerMove).enabled = false;
 	}
}

function Start()
{
	if(GetComponent.<NetworkView>().isMine)
	{
		GetComponent.<NetworkView>().RPC("setPlayer", RPCMode.AllBuffered);
	}
}

function Update()
{
	if(!(GameObject.Find("Scripts").GetComponent("networking") as networking).waiting)
	{
		GetComponent.<NetworkView>().RPC("iniciarCuenta", RPCMode.AllBuffered);
	}

	if(GetComponent.<NetworkView>().isMine)
	{
		GetComponent(playerMove).enabled = (GameObject.FindGameObjectWithTag("RaceInfo").GetComponent("CarreraInfo") as CarreraInfo).iniciarCarrera;
	}
}

function retardo(t : float) : IEnumerator
{
	couroutineStarted = true;
	yield WaitForSeconds(t);
	tiempo--;
	couroutineStarted = tiempo == -1;
}

@RPC
function iniciarCuenta()
{
	(GameObject.Find("Scripts").GetComponent("networking") as networking).waiting = false;
	GameObject.Find ("Canvas").transform.FindChild("Contador").gameObject.SetActive(true);

	if(!couroutineStarted)
         StartCoroutine(retardo(1));

	(GameObject.Find ("Canvas").transform.FindChild("Contador").gameObject.GetComponent("Text") as Text).text = tiempo > 0 ? tiempo.ToString() : "Corre!";

	if(tiempo == -1)
	{
		GameObject.Find ("Canvas").transform.FindChild("Contador").gameObject.SetActive(false);
		(GameObject.FindGameObjectWithTag("RaceInfo").GetComponent("CarreraInfo") as CarreraInfo).iniciarCarrera = true;
	}
}

@RPC
function setPlayer() // Inicializa las preferencias del jugador en la sala. :)
{
	var kart = new Transform[8];

    kart[0] = transform.FindChild("Rojo");
	kart[1] = transform.FindChild("Azul");
	kart[2] = transform.FindChild("Amarillo");
	kart[3] = transform.FindChild("Verde");
	kart[4] = transform.FindChild("Blanco");
	kart[5] = transform.FindChild("Rosa");
	kart[6] = transform.FindChild("Morado");
	kart[7] = transform.FindChild("Negro");

	for(var i : int = 0; i < kart.Length; i++)
		kart[i].gameObject.SetActive(false);

	kart[PlayerPrefs.GetInt("kart")].gameObject.SetActive(true);

	transform.FindChild("Información").gameObject.GetComponent(TextMesh).text = PlayerPrefs.GetString("nombre");

	(transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).kartSelected = PlayerPrefs.GetInt("kart");
	(transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).nombre = PlayerPrefs.GetString("nombre");
}