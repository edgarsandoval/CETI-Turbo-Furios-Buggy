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
	Application.LoadLevel("Offline");
}

public function BotonSalir()
{
	Application.Quit();
}