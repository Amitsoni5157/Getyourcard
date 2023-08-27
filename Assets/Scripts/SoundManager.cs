using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource cardFlip;
    public AudioSource cardMatch;

    public void PlayCardMatchMusic()
    {
        cardMatch.Play();

    }

    public void PlayCardFlipMusic()
    {
        cardFlip.Play();
    }


}
