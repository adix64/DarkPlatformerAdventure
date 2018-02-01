using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	public static AudioManager instance;

	void Awake()
	{
	//	if (instance == null)
	//		instance = this;
	//	else
	//	{
	//		Destroy (gameObject);
	//		return;
		//}
		//DontDestroyOnLoad (gameObject);
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start()
	{
		Play ("ShepardTone");
		Play ("Rain");
	}

	public void Play(string name)
	{

		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Play ();
	}

	public void Stop(string name)
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Stop();
	}

	public void StopAllMusic()
	{
		foreach (Sound s in sounds)
		{
			if (s.type != "Music")
				continue;
			s.source.Stop();
		}
	}

	public void StopAllAmbient()
	{
		foreach (Sound s in sounds)
		{
			if (s.type != "Ambient")
				continue;
			s.source.Stop();
		}
	}

	public void SetSFXVolume(Slider slider)
	{
		foreach (Sound s in sounds)
		{Debug.Log (s.type);
			if (s.type != "SFX")
				continue;
			Debug.Log ("SFX VOLUME:" + slider.value);	
			s.source.volume = slider.value;
		}
	}
	public void SetMusicVolume(Slider slider)
	{
		Debug.Log ("SETMUSICVOL" + slider.value);
		foreach (Sound s in sounds)
		{
			Debug.Log (s.type);
			if (s.type != "Music")
				continue;
			Debug.Log ("Music VOLUME:" + slider.value);	
			s.source.volume = slider.value;
		}
	}
	public void SetAmbientVolume(Slider slider)
	{
		foreach (Sound s in sounds)
		{Debug.Log (s.type);
			if (s.type != "Ambient")
				continue;
			Debug.Log ("Ambient VOLUME:" + slider.value);	
			s.source.volume = slider.value;
		}

	}
}
