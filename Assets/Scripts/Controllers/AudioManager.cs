using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource ambientSoundSource;
    public float ambientSoundVolume = 0.6f;
    
    public AudioSource collideSoundSource;
    public float collideSoundVolume = 0.75f;

    public void PlayCollideSound()
    {
        if (collideSoundSource is null || collideSoundSource.isPlaying) return;

        collideSoundSource.volume = collideSoundVolume;
        collideSoundSource.Play();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (ambientSoundSource is null) return;
        ambientSoundSource.loop = true;
        ambientSoundSource.volume = ambientSoundVolume;
        ambientSoundSource.Play();
    }
}
