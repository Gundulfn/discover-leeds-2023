using UnityEngine;
 
public class SoundController : MonoBehaviour
{
    private AudioSource aud;
    private bool isLooping;
    private static float audVolume = 1;

    protected virtual void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.volume = audVolume;
    }

    void Update()
    {
        if(aud.volume != audVolume)
        {
            aud.volume = audVolume;
        }
    }

    public void Play(AudioClip audioClip = null)
    {
        if(!aud.isPlaying)
        {
            PlayImmediately(audioClip);
        }
    }

    public void PlayImmediately(AudioClip audioClip = null)
    {
        if(audioClip)
        {
            aud.clip = audioClip;
        }
        
        aud.Play();
    }

    public void PlayLoop(AudioClip audioClip)
    {
        if(aud.clip != audioClip || !aud.loop)
        {
            PlayImmediately(audioClip);
        }
    }

    public void ContinueLoop()
    {
        aud.loop = true;
    }

    public void StopLoop()
    {
        aud.loop = false;
    }

    public void OnValueChanged(float value)
    {
        audVolume = value;
    }
}