using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseMenu : MonoBehaviour {
	public static bool GameIsPaused = false;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (GameIsPaused) {
				ResumeGame ();
			} else {
				PauseGame ();
			}
		}
	}

	public void ResumeGame()
	{
		GameIsPaused = false;
		Time.timeScale = 1.0f;
		transform.GetChild (0).gameObject.SetActive (false);
	}

	void PauseGame()
	{
		GameIsPaused = true;
		Time.timeScale = 0.0f;
		transform.GetChild (0).gameObject.SetActive (true);
		transform.GetChild (0).gameObject.transform.Find ("MainMenu").gameObject.SetActive (true);
		transform.GetChild (0).gameObject.transform.Find ("OptionsMenu").gameObject.SetActive (false);
	}
}
