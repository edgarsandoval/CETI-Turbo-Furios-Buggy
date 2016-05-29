using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManejadorEscenas : MonoBehaviour
{
	public Slider loadingBar;
	public GameObject loadingImage;

	private AsyncOperation async;

	void Start ()
	{
		loadingImage.SetActive (true);
		StartCoroutine (LoadLevelWithBar());
	}
	
	IEnumerator LoadLevelWithBar()
	{
		string escena = PlayerPrefs.GetString ("nextScene");
		async = Application.LoadLevelAsync (escena);

		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}
