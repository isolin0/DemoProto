//Isolino
using UnityEngine.Audio;
using System;
using UnityEngine;


public class UIAudioManager : MonoBehaviour
{


	public Sound[] sound;

	public static UIAudioManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}


		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sound)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

	}

	private void Start()
	{
		Play("Theme");
	}


	public void Play(string name)
	{
		Sound s = Array.Find(sound, sound => sound.name == name);
		if (s == null)
		{
			//Debug.LogWarning("Sound: " + name + " not found");
			return;
		}

		s.source.Play();

		//para llamar esta funcion y reproducir un sonido de la lista
		//podemos ejecutar 
		//  FindObjectOfType<AudioManager>().Play("Nombre del audio clip");
	}
	public void Stop(string name)
	{
		Sound s = Array.Find(sound, sound => sound.name == name);
		if (s == null)
		{
			//Debug.LogWarning("Sound: " + name + " not found");
			return;
		}

		s.source.Stop();

		//para llamar esta funcion y pausar un sonido de la lista
		//podemos ejecutar 
		//  FindObjectOfType<AudioManager>().Stop("Nombre del audio clip");
	}


}