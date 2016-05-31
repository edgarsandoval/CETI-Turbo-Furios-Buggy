import UnityEngine.UI;

var mainMenuSceneName : String;
var pauseMenuFont : Font;
private var pauseEnabled = false;	

function Start(){
	QualitySettings.currentLevel = QualityLevel.Fast;
	pauseEnabled = false;
	Time.timeScale = 1;
	AudioListener.volume = 1;
}

function Update(){

	//checa si el botón de pausa (tecla "escape"), es presionada
	if(Input.GetKeyDown("escape")){
		menuPausa();
	}
}

private var showGraphicsDropDown = false;

function OnGUI(){

GUI.skin.box.font = pauseMenuFont;
GUI.skin.button.font = pauseMenuFont;

	if(pauseEnabled == true){
		
		//Crea la caja de fondo
		GUI.Box(Rect(Screen.width /2 - 100,Screen.height /2 - 100,250,200), "Menu de pausa");

		//Crea el botón "Continuar"
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 50,250,50), "Continuar"))
		{
			pauseEnabled = true;
			showGraphicsDropDown = false;
			menuPausa();			
		}

		//Crea el botón "Cambiar Calidad Gráfica"
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 ,250,50), "Cambiar calidad grafica")){
			
			if(showGraphicsDropDown == false){
				showGraphicsDropDown = true;
			}
			else{
				showGraphicsDropDown = false;
			}
		}
		
		//Crea botón de "Ajustes gráficos", este no se muestra automáticamente, este puede ser llamado cuando
		//el usuario ckicklee el botón de "Cambiar Calidad Gráfica", y desaparece cuando clickean el botón
		//otra vez....
		if(showGraphicsDropDown == true){
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 ,250,50), "Horribles")){
				QualitySettings.currentLevel = QualityLevel.Fastest;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 50,250,50), "Bajos")){
				QualitySettings.currentLevel = QualityLevel.Fast;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 100,250,50), "Medios")){
				QualitySettings.currentLevel = QualityLevel.Simple;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 150,250,50), "Normales")){
				QualitySettings.currentLevel = QualityLevel.Good;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 200,250,50), "Buenos")){
				QualitySettings.currentLevel = QualityLevel.Beautiful;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 250,250,50), "Excelentes")){
				QualitySettings.currentLevel = QualityLevel.Fantastic;
			}
			
			if(Input.GetKeyDown("escape")){
				showGraphicsDropDown = false;
			}
		}

		//Crea botón "Salir del juego" -  regresa al menú principal. 
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Salir del juego"))
		{
			PlayerPrefs.SetString("nextScene", "menu");
			Application.LoadLevel("Transicion");
			Destroy(transform.parent.gameObject);
		}
	}
}

public function menuPausa()
{
	//checa si el juego está pausado		
	if(pauseEnabled == true){
		//despausa el juego
		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
	}
	//de lo contrario, si el juego no está pausado, entonces lo pausa
	else if(pauseEnabled == false){
		pauseEnabled = true;
		AudioListener.volume = 0;
		Time.timeScale = 0;
	}
}