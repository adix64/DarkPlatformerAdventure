using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour {

	public bool fullscreen = false;
	int width, height;
	public void SetResolution (int option)
	{
		switch (option)
		{
		case 0:
			width = 800;
			height = 450;
			break;
		case 1:
			width = 1280;
			height = 720;
			break;
		case 2:
			width = 1366;
			height = 768;
			break;
		case 3:
			width = 1920;
			height = 1080;
			break;
		default:
			width = 800;
			height = 450;
			break;

		}
		Screen.SetResolution(width, height, fullscreen);
	}
	public void SetFullscreen(bool val)
	{
		fullscreen = val;
		Screen.SetResolution(width, height, val);
	}

}
