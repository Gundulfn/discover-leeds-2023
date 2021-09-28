using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource aud;

    // Add music change later
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void OnValueChanged(float value)
    {
        aud.volume = value;
    }
}
