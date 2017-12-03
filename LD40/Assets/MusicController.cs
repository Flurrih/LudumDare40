using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] musics;

    private AudioClip current;
    private AudioSource source;

    private float timer;

	void Start ()
	{
	    source = GetComponent<AudioSource>();
	    current = musics[Random.Range(0, musics.Length)];
	    source.clip = current;
        source.Play();

	    timer = 0;
	}
	
	void Update () {
	    if (timer >= source.clip.length)
	    {
	        current = musics[Random.Range(0, musics.Length)];
	        source.clip = current;
	        source.Play();
            timer = 0;
	    }
	    timer += Time.unscaledDeltaTime;
	}
}
