var mainMenuSceneName : String;
var pauseMenuFont : Font;
private var pauseEnabled = false;			

function Start(){
	QualitySettings.currentLevel = QualityLevel.Fast;
	pauseEnabled = false;
	Time.timeScale = 1;
	AudioListener.volume = 1;
	Cursor.visible = false;
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
		
		//Make a background box
		GUI.Box(Rect(Screen.width /2 - 100,Screen.height /2 - 100,250,200), "Pause Menu");

		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 - 50,250,50), "Continuar"))
		{
			pauseEnabled = true;
			showGraphicsDropDown = false;
			menuPausa();			
		}

		
		//Make Change Graphics Quality button
			if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 ,250,50), "Cambiar calidad gráfica")){
			
			if(showGraphicsDropDown == false){
				showGraphicsDropDown = true;
			}
			else{
				showGraphicsDropDown = false;
			}
		}
		
		//Create the Graphics settings buttons, these won't show automatically, they will be called when
		//the user clicks on the "Change Graphics Quality" Button, and then dissapear when they click
		//on it again....
		if(showGraphicsDropDown == true){
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 ,250,50), "Fastest")){
				QualitySettings.currentLevel = QualityLevel.Fastest;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 50,250,50), "Fast")){
				QualitySettings.currentLevel = QualityLevel.Fast;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 100,250,50), "Simple")){
				QualitySettings.currentLevel = QualityLevel.Simple;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 150,250,50), "Good")){
				QualitySettings.currentLevel = QualityLevel.Good;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 200,250,50), "Beautiful")){
				QualitySettings.currentLevel = QualityLevel.Beautiful;
			}
			if(GUI.Button(Rect(Screen.width /2 + 150,Screen.height /2 + 250,250,50), "Fantastic")){
				QualitySettings.currentLevel = QualityLevel.Fantastic;
			}
			
			if(Input.GetKeyDown("escape")){
				showGraphicsDropDown = false;
			}
		}

		//Make Main Menu button
		if(GUI.Button(Rect(Screen.width /2 - 100,Screen.height /2 + 50,250,50), "Salir del juego"))
		{
			Application.LoadLevel(mainMenuSceneName);
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
		Cursor.visible = false;			
	}
	
	//de lo contrario, si el juego no está pausado, entonces lo pausa
	else if(pauseEnabled == false){
		pauseEnabled = true;
		AudioListener.volume = 0;
		Time.timeScale = 0;
		Cursor.visible = true;
	}
}