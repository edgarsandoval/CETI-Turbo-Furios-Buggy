function Start() {
	//PlayerPrefs.DeleteAll();
	/* La borradora */
}

public function BotonJugar()
{
	Application.LoadLevel("SelectorMapa");
}

public function BotonPersonaje()
{
	Application.LoadLevel("Selector");
}

public function BotonMultiplayer()
{
	Application.LoadLevel("MapaMultijugador");
}

public function BotonSalir()
{
	Application.Quit();
}