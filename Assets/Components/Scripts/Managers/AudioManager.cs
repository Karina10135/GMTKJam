using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public float fadeSpeed;
    public float currentFade;
    bool fade;

    public static AudioManager audioManager;

    private void Start()
    {
        audioManager = this;
        

        source = Camera.main.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (fade)
        {
            if(currentFade <= 0)
            {
                currentFade = 0;
                fade = false;
                //source.volume = 1;
            }
            else
            {
                currentFade -= Time.deltaTime * fadeSpeed;
                source.volume = currentFade;
            }
        }
    }

    public void PlaySound(AudioClip audio)
    {
        source.clip = audio;
        source.Play();
    }

    public void FadeSound()
    {
        fade = true;
        currentFade = 1;
    }
	
}
