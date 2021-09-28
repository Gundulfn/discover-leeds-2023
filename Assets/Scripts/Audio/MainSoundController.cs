using UnityEngine;

public class MainSoundController: SoundController
{
    public static MainSoundController instance;

    protected override void Start()
    {
        instance = this;
        base.Start();
    }
}