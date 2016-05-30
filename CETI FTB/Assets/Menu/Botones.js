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
	Application.LoadLevel("Main");
}

public function BotonSalir()
{
	Application.Quit();
}