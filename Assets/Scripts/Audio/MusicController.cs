using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip slowMusicClip, fastMusicClip;
    private AudioSource aud;
    private bool isFastMusicPlaying;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.clip = slowMusicClip;
        aud.Play();
    }

    public void ChangeMusic(bool playFastMusic)
    {
        if(playFastMusic && aud.clip != fastMusicClip)
        {
            aud.clip = fastMusicClip;
            aud.Play();
        }
        else if(!playFastMusic && aud.clip != slowMusicClip)
        {
            aud.clip = slowMusicClip;
            aud.Play();
        }
    }

    public void OnValueChanged(float value)
    {
        aud.volume = value;
    }
}