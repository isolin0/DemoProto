using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
	public string soundName;
	public bool is3dSound;
	public AudioSource myAudioSource;

	

	private void Start()
	{
		
		if(myAudioSource !=null)
			myAudioSource = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (is3dSound)
			{
				myAudioSource.Play();
			}
			else
			{
				if(soundName!=null)
				FindObjectOfType<AudioManager>().Play(soundName);
			}
		
			
			
		}
	}
			
	
}
