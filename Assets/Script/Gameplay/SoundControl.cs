using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
	private AudioSource audioSource;
	public static AudioSource audioPlayer;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioPlayer = audioSource;
	}
}
