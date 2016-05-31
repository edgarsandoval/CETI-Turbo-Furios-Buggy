var cuenta : GUIText = GetComponent("GUIText") as GUIText;
var cuentaMaxima : int = 3;
var cuentaAtras : int;

public function iniciarJuego()
{

	for(cuentaAtras = cuentaMaxima; cuentaAtras > 0; cuentaAtras--)
	{
		cuenta.text = cuentaAtras.ToString();
		yield WaitForSeconds(1);
	}

	cuenta.text = "Jalele!";
	yield WaitForSeconds(1);

	cuenta.gameObject.setActive(false);
}