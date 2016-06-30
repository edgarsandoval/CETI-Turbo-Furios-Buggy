@script ExecuteInEditMode()

/* Declare a GUI Style */
var buttonGUISytle : GUIStyle;
var labelGUIStyle : GUIStyle;
var textFieldGUIStyle : GUIStyle;
var titleGUIStyle : GUIStyle;
/*                         */

var gameName : String = "CETI - FTB"; 
	
var refreshing = false; 
var hostData : HostData[];

var playerPrefab : GameObject;
var raceInfo : GameObject;
 
private var kart : Transform[];

var create = false;
var joining = false;
var waiting = false;

private var serverName = "";
private var serverInfo = "";
private var serverPass = "";
private var playerName = "";
private var kartSelected = 0;
private var clientPass = "";
private var scrollPosition : Vector2 = Vector2.zero;

private var spawnPoints : Vector3[,] = new Vector3[4, 8];

function Start()
{
	spawnPoints[0, 0] = Vector3 (50.64661f, 4.401484f, 11.26688f);
	spawnPoints[1, 0] = Vector3 (257.9f, 13.80426f, -71.75798f);
	spawnPoints[2, 0] = Vector3 (302.5f, 15.63f, 175.7f);
	spawnPoints[3, 0] = Vector3 (-102.4f, 13.3f, 235.6f);

	playerName = PlayerPrefs.HasKey("nombre") || PlayerPrefs.GetString("nombre") != "" ? PlayerPrefs.GetString("nombre") : "SinNombre"; 
	kartSelected = PlayerPrefs.HasKey("kart") ? PlayerPrefs.GetInt("kart") : 0;
} 
 
function OnGUI ()
{
    if(!Network.isClient && !Network.isServer)
    {
        // Si no estás como cliente ni como servidor, entra al menú principal del mulijugador. 
        if(!create && !joining && !waiting)
        {
            if (GUI.Button(Rect(Screen.width/2 - 125, Screen.height / 2 - 85, 250, 100),"Crear Juego", buttonGUISytle))
            {
                create = true;
            }
     
            if (GUI.Button(Rect(Screen.width/2 - 125, Screen.height/2 + 30, 250, 100), "Encontrar juego", buttonGUISytle))
            {
                joining = true;
                refreshHostList();
            }
        }
      
        if (create) // Al crear una partida, muestra el menú del servidor. 
        {

            if (GUI.Button(Rect(Screen.width/2 - 100 , Screen.height/3 + 150, 200, 80),"Crear partida", buttonGUISytle))
            {
                startServer();
            }

            GUI.Label(Rect (Screen.width/2 - 135, Screen.height / 3 - 50, 100, 20), "Nombre del Servidor:", labelGUIStyle);
            GUI.Label(Rect (Screen.width/2 + 50,Screen.height/3 - 50,100,20),"Contraseña:", labelGUIStyle);
            GUI.Label(Rect (Screen.width/2 - 40	,Screen.height / 3 + 250, 120 ,20),"Información:", labelGUIStyle);

            GUI.Label(Rect (Screen.width/2 - 50	,Screen.height/3 + 40, 120 ,20), "Selecciona un mapa:", labelGUIStyle);

           	if (GUI.Button(Rect(Screen.width/3 - 170, Screen.height/3 + 65, 180, 80)," Primer Nivel", buttonGUISytle))
            {
                PlayerPrefs.SetInt("mapa", 1);
            }

           	if (GUI.Button(Rect(Screen.width/3 + 50, Screen.height/3 + 65, 180, 80)," Segundo Nivel", buttonGUISytle))
            {
                PlayerPrefs.SetInt("mapa", 2);
            }

           	if (GUI.Button(Rect(Screen.width/3 + 260, Screen.height/3 + 65, 180, 80)," Tercer Nivel", buttonGUISytle))
            {
                PlayerPrefs.SetInt("mapa", 3);
            }

            serverName = GUI.TextField (Rect (Screen.width/2 - 130,Screen.height/3 - 50 + 30, 120, 30), serverName, 12, textFieldGUIStyle);
            serverPass = GUI.PasswordField (Rect (Screen.width/2 + 30,Screen.height/3 - 50 + 30,120, 30), serverPass, "*"[0], 12, textFieldGUIStyle);
            serverInfo = GUI.TextArea (Rect (Screen.width/2 - 100,Screen.height/ 3 + 300, 200, 60), serverInfo, 35, textFieldGUIStyle);

            if (GUI.Button(Rect(Screen.width/1.2 - 25,Screen.height/20, 150, 100),"Atras", buttonGUISytle))
            {
            	create = false;
            }
        }
      
        if (joining) // Al entrar como cliente muestra las partidas existentes. 
        {
            if(hostData)
            {
                //scrollPosition = GUI.BeginScrollView (Rect (Screen.width/4,Screen.height/6,Screen.width/1.5,Screen.height/2),scrollPosition, Rect (0, 0, 300, 1000/hostData.length * 30));
                scrollPosition = GUI.BeginScrollView (Rect (Screen.width / 2 - 275, Screen.height / 6 + 30, Screen.width, Screen.height / 2),scrollPosition, Rect (0, 0, 300, 1000 / hostData.length * 30));

                GUI.Label(Rect(30,0,100,20),"Nombre", labelGUIStyle);
                GUI.Label(Rect(150,0,100,20),"Informacion", labelGUIStyle);
                GUI.Label(Rect(240,0,100,20),"Jugadores", labelGUIStyle);
                GUI.Label(Rect(360,0,100,20),"Contraseña", labelGUIStyle);

                for(var i = 0; i < hostData.length; i++)
                {
                	
                    GUI.Label(Rect(30,30 + i * 30,100,22),hostData[i].gameName, labelGUIStyle);
                    GUI.Label(Rect(150,30 + i * 30,100,22),hostData[i].comment, labelGUIStyle);
                    GUI.Label(Rect(240,30 + i * 30,100,20),hostData[i].connectedPlayers + " / " + hostData[i].playerLimit, labelGUIStyle);

                    if (hostData[i].passwordProtected)
                    {
                        clientPass = GUI.PasswordField (Rect (360,30 + i * 30,100,25), clientPass, "*"[0], 12, textFieldGUIStyle);
                    }
                     
                    if (GUI.Button(Rect(480,30 + i * 30 - 10, 150, 50),"Entrar", buttonGUISytle))
                    {
                        Debug.Log(Network.Connect(hostData[i], clientPass))	;
                    }
                }

                GUI.EndScrollView ();
            }
               
            if(!hostData) // Si no hay servidores disponibles. :(
            {
                GUI.Label(Rect(Screen.width/2 - 80,Screen.height/3,200,25),"Ningun juego encontrado. :(", labelGUIStyle);

                if (GUI.Button(Rect(Screen.width/2 - 125,Screen.height/3 + 50, 250, 100),"Refrescar lista", buttonGUISytle))
                {
                    refreshHostList();
                }
            }
       
            if (GUI.Button(Rect(Screen.width/1.2 - 25,Screen.height/20, 150, 100),"Atras", buttonGUISytle))
            {
                  joining = false;
            }
        }

        if (GUI.Button(Rect(Screen.width/20,Screen.height/20, 250, 100), "Regresar al menu", buttonGUISytle))
        {
            Application.LoadLevel("menu");
        }
    }

    if(waiting) // Entró a la sala de espera. :)
    {
    	if(Network.isServer)
        {
        	GUI.Box(Rect(100, 100, 575, 450), "");
	        GUI.Label(Rect(Screen.width / 2 - 100, Screen.height/2 - 11, 200,22), "Jugadores en la sala : " + (Network.connections.Length + 1) + "/" + (Network.maxConnections + 1), titleGUIStyle);

	        if(Network.connections.Length > 0)
		        if (GUI.Button(Rect(Screen.width/2 - 110,Screen.height/2 + 150, 220, 80),"Iniciar Carrera", buttonGUISytle))
		        {
		            iniciarCarrera();
		        }
	    }
	    else
	    {
	    	GUI.Box(Rect(100, 100, 575, 450), "");
	    	GUI.Label(Rect(Screen.width / 2 - 100, Screen.height/2 - 11, 200,22), "Esperando al servidor", titleGUIStyle);
	    }
    }

}

function Update ()
{
    if(refreshing)
    {
        if(MasterServer.PollHostList().Length > 0)
        {
            refreshing = false;
            hostData = MasterServer.PollHostList();
        }
    }
}

function startServer ()
{ 
    if (serverPass != "")
    {
        Network.incomingPassword = serverPass;
    }

    if(serverName == "")
    {
    	serverName = "Sin nombre";
    }
 
    Network.InitializeServer(7,25001, !Network.HavePublicAddress);
    MasterServer.RegisterHost(gameName, serverName, serverInfo);
}

public function iniciarCarrera()
{
	waiting = false;
}

function OnServerInitialized ()
{ 
    DontDestroyOnLoad (transform.gameObject);

    waiting = true;
    Network.Instantiate(raceInfo, transform.position, transform.rotation, 0);
    lobbySpawn();
}

function OnConnectedToServer ()
{	
	waiting = true;
	Debug.Log("Conectado :)");
    lobbySpawn();
}

function lobbySpawn()
{
    //yield WaitForSeconds(0.1);
    var made = Network.Instantiate(playerPrefab, DP(Network.connections.Length), Quaternion.Euler (0, 190, 0), 0);

    PlayerPrefs.SetString("nombre", playerName);
    PlayerPrefs.SetInt("kart", kartSelected);
}

function refreshHostList ()
{ 
    MasterServer.ClearHostList();
    MasterServer.RequestHostList(gameName);
    refreshing = true;
}

function DP(n : int)
{
	var x : int = PlayerPrefs.GetInt("mapa") - 1;
	if(spawnPoints[x, n] != Vector3.zero)
		return spawnPoints[x, n];
	else
	{
		spawnPoints[x, n] = spawnPoints[x, n - 1];
	 
		if(n % 2)
			spawnPoints[x, n].x -= 10;
		else
		{
			spawnPoints[x, n].x += 10;
			spawnPoints[x, n].z += 10;
		}

		return spawnPoints[x, n];
	}
}
