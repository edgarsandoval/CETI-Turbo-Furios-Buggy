#pragma strict

function Awake()
{
	if (!GetComponent.<NetworkView>().isMine)
	{
   		GetComponentInChildren(Camera).enabled = false;
   		GetComponent(playerMove).enabled = false;
 	}
}