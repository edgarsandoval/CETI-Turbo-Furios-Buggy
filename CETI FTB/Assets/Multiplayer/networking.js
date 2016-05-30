@script ExecuteInEditMode()

/* Declare a GUI Style */
var buttonGUISytle : GUIStyle;
var labelGUIStyle : GUIStyle;
var textFieldGUIStyle : GUIStyle;
var titleGUIStyle : GUIStyle;
/*                         */

var gameName : String = "Sin nombre"; 
	
var refreshing = false; 
var hostData : HostData[]; // a list of all current hosts

var playerPrefabs : GameObject[]; // your player

var create = false;
var joining = false;
var waiting = false;

var serverName = "";
var serverInfo = "";
var serverPass = "";

var playerName = "";

var clientPass = "";

var scrollPosition : Vector2 = Vector2.zero;

function Start()
{
  playerName = PlayerPrefs.HasKey("nombre") || PlayerPrefs.GetString("nombre") != "" ? PlayerPrefs.GetString("nombre") : "NuevoJugador" + Random.Range(0, 50); 
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

            if (GUI.Button(Rect(Screen.width/2 - 75,Screen.height/3 + 100, 150, 80),"Crear", buttonGUISytle))
            {
                startServer();
            }

            GUI.Label(Rect (Screen.width/2 - 135, Screen.height / 3, 100, 20), "Nombre del Servidor:", labelGUIStyle);
            GUI.Label(Rect (Screen.width/2 + 50,Screen.height/3,100,20),"Contraseña:", labelGUIStyle);
            GUI.Label(Rect (Screen.width/2 - 65,Screen.height/2 + 90,100,20),"Información Adicional:", labelGUIStyle);

            serverName = GUI.TextField (Rect (Screen.width/2 - 130,Screen.height/3 + 30, 120, 30), serverName, 12, textFieldGUIStyle);
            serverPass = GUI.PasswordField (Rect (Screen.width/2 + 30,Screen.height/3 + 30,120, 30), serverPass, "*"[0], 12, textFieldGUIStyle);
            serverInfo = GUI.TextArea (Rect (Screen.width/2 - 100,Screen.height/2 	+ 120, 200, 60), serverInfo, 35, textFieldGUIStyle);

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
                GUI.Label(Rect(360	,0,100,20),"Contraseña", labelGUIStyle);

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
                    	Debug.Log("lol");
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
	        scrollPosition = GUI.BeginScrollView (Rect (Screen.width / 2 - 275, Screen.height / 6 + 30, Screen.width / 1.5, Screen.height / 2),scrollPosition, Rect (0, 0, 300, 1000 / 1 * 30));
	        GUI.Label(Rect(30,0,100,20),"Lugar", labelGUIStyle);
	        GUI.Label(Rect(350,0,100,20),"IP", labelGUIStyle);

	        GUI.Label(Rect(0,20 * 3,200,22), "1", textFieldGUIStyle);
	        GUI.Label(Rect(160,20 * 3,500,22), "localhost", textFieldGUIStyle);

	        for(var j = 0; j < Network.connections.Length; j++)
	        {
	            GUI.Label(Rect(0,(20 + ( 10 * (j + 1))) * 30,200,22), "" + (j + 2), labelGUIStyle);
	            GUI.Label(Rect(160,(20 + (10 * (j + 1))) * 30,500,22), Network.connections[j].externalIP, labelGUIStyle);
	        }

	        GUI.EndScrollView();

	        if (GUI.Button(Rect(Screen.width/2 - 110,Screen.height/2 + 150, 220, 80),"Iniciar Carrera", buttonGUISytle))
	        {
	            iniciarCarrera();
	        }
	    }
	    else
	    {
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
 
    Network.InitializeServer(7,25001, !Network.HavePublicAddress);
    MasterServer.RegisterHost(gameName, serverName, serverInfo);
}

public function iniciarCarrera()
{
	waiting = false;
	PlayerPrefs.SetString("nextScene", "MapaMultijugador");
	Application.LoadLevel("Transicion");
	lobbySpawn();
}

function OnServerInitialized ()
{ 
    DontDestroyOnLoad (transform.gameObject);
    create = false;
    waiting = true;
}

function OnConnectedToServer ()
{	
	waiting = true;
    lobbySpawn();
}

function lobbySpawn()
{
    yield WaitForSeconds(0.1);
    var made = Network.Instantiate(playerPrefabs[PlayerPrefs.GetInt("kart")], transform.position, transform.rotation, 0);
    made.GetComponent(playerMove).playerName = playerName;
    PlayerPrefs.SetString("nombre", playerName);
    if(Network.isClient)
    {
        Destroy(this);
    }
}

function refreshHostList ()
{ 
    MasterServer.ClearHostList();
    MasterServer.RequestHostList(gameName);
    refreshing = true;
}
