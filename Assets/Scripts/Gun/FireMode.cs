using UnityEngine;
using TMPro;

public class FireMode: MonoBehaviour
{
    public int currentFireModeNo
    {
        get;
        private set;
    }

    public TextMeshProUGUI fireModeText;
    public MusicController musicController;

    void Start()
    {
        currentFireModeNo = 1;
        fireModeText.SetText("Fire Mode: Slow");
    }

    void Update()
    {
        if(!UIHandler.IsCreditsUIActive)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                SetFireMode(false);
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                SetFireMode(true);
            }
        }
    }

    public void SetFireMode(bool isIncreasing)
    {
        currentFireModeNo += (isIncreasing? 1: -1);

        if(currentFireModeNo < 0)
        {
            currentFireModeNo += 3;
        }

        currentFireModeNo %= 3;

        switch (currentFireModeNo)
        {
            case FireModeSettings.SINGLE_SHOT_NO:
                fireModeText.SetText("Fire Mode: Single Shot");
                musicController.ChangeMusic(false);
                break;

            case FireModeSettings.SLOW_SHOT_NO:
                fireModeText.SetText("Fire Mode: Slow");
                musicController.ChangeMusic(false);
                break;

            case FireModeSettings.FAST_SHOT_NO:
                fireModeText.SetText("Fire Mode: Fast");
                musicController.ChangeMusic(true);
                break;   

            default:
                break;
        }
    }
}