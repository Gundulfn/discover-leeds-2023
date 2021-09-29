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

    void Start()
    {
        currentFireModeNo = 1;
        fireModeText.SetText("Fire Mode: Slow");
    }

    void Update()
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
                break;

            case FireModeSettings.SLOW_SHOT_NO:
                fireModeText.SetText("Fire Mode: Slow");
                break;

            case FireModeSettings.FAST_SHOT_NO:
                fireModeText.SetText("Fire Mode: Fast");
                break;   

            default:
                break;
        }
    }
}