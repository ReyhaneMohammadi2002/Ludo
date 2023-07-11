using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public  AudioClip buttonAudioClip;
    public  AudioClip diceRollingAudioClip;
    public  AudioClip failAudioClip;
    public  AudioClip goInHouseAudioClip;
    public  AudioClip winningAudioClip;

    public static AudioSource buttonAusioSource;
    public static  AudioSource diceRollingAusioSource;
    public static AudioSource failAusioSource;
    public static AudioSource goInHouseAusioSource;
    public static  AudioSource winningAusioSource;

    AudioSource AddAudio(AudioClip clip, bool playonawke, bool loop, float volume )
    {
        AudioSource ausioSource = gameObject.AddComponent<AudioSource>(); ;
        ausioSource.clip = clip;
        ausioSource.playOnAwake = playonawke;
        ausioSource.loop = loop;
        ausioSource.volume = volume;
        return ausioSource;
    }
        void Start()
    {
        buttonAusioSource = AddAudio(buttonAudioClip, true, false, 1.0f);
        diceRollingAusioSource = AddAudio(diceRollingAudioClip, true, false, 1.0f);
        failAusioSource = AddAudio(failAudioClip, true, false, 1.0f);
        goInHouseAusioSource = AddAudio(goInHouseAudioClip, true, false, 1.0f);
        winningAusioSource = AddAudio(winningAudioClip, true, false, 1.0f);
    }

    
  
}
