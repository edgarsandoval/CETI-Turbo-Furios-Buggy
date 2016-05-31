#pragma strict

function Awake()
{
	if (!GetComponent.<NetworkView>().isMine)
	{
   		GetComponentInChildren(Camera).enabled = false;
   		GetComponent(playerMove).enabled = false;
 	}
}

function Update()
{
	if(!(GameObject.Find("Scripts").GetComponent("networking") as networking).waiting)
	{
		(GameObject.FindGameObjectWithTag("RaceInfo").GetComponent("CarreraInfo") as CarreraInfo).iniciarCarrera = true;
		GetComponent.<NetworkView>().RPC("iniciarCuenta", RPCMode.AllBuffered);
	}

	if(GetComponent.<NetworkView>().isMine)
	{
		GetComponent(playerMove).enabled = (GameObject.FindGameObjectWithTag("RaceInfo").GetComponent("CarreraInfo") as CarreraInfo).iniciarCarrera;
	}

	//GetComponent.<NetworkView>().RPC("setPlayers", RPCMode.AllBuffered);
}

@RPC
function iniciarCuenta()
{
	//Debug.Log(transform.FindChild("Información").gameObject.GetComponent("CuentaRegresiva"));
	//(transform.FindChild("Información").gameObject.GetComponent("CuentaRegresiva") as CuentaRegresiva).iniciarJuego();

	(GameObject.FindGameObjectWithTag("RaceInfo").GetComponent("CarreraInfo") as CarreraInfo).iniciarCarrera = true;
	(GameObject.Find("Scripts").GetComponent("networking") as networking).waiting = false;
}

/*@RPC
function setPlayers()
{

	for(var jugador : GameObject in GameObject.FindGameObjectsWithTag("Player"))
	{
		if(jugador.GetComponent.<NetworkView>().isMine)
		{
			if(!(jugador.transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).isSeted)
			{
				(jugador.transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).nombre = PlayerPrefs.GetString("nombre");
				(jugador.transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).kartSelected = PlayerPrefs.GetInt("kart");

				jugador.transform.FindChild("Información").gameObject.GetComponent(TextMesh).text = PlayerPrefs.GetString("nombre");

				var kart = new Transform[8];

			    kart[0] = jugador.transform.FindChild("Rojo");
				kart[1] = jugador.transform.FindChild("Azul");
				kart[2] = jugador.transform.FindChild("Amarillo");
				kart[3] = jugador.transform.FindChild("Verde");
				kart[4] = jugador.transform.FindChild("Blanco");
				kart[5] = jugador.transform.FindChild("Rosa");
				kart[6] = jugador.transform.FindChild("Morado");
				kart[7] = jugador.transform.FindChild("Negro");

				for(var i : int = 0; i < kart.Length; i++)
					kart[i].gameObject.SetActive(false);

				kart[PlayerPrefs.GetInt("kart")].gameObject.SetActive(true);

				(jugador.transform.FindChild("Información").gameObject.GetComponent("PlayerInfo") as PlayerInfo).isSeted = true;
			}
		}
	}
}*/