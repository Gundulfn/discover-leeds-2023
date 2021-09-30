using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    private static bool isUIActive = true;
    public static bool IsUIActive
    {
        get{ return isUIActive; }
        private set{ isUIActive = value; }
    }

    private static bool isCreditsUIActive;
    public static bool IsCreditsUIActive
    {
        get{ return isCreditsUIActive; }
        private set{ isCreditsUIActive = value; } 
    }

    public GameObject mainUIObj, entranceUIObj, creditsUIObj;
    public AudioClip buttonClickSound;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && entranceUIObj.activeSelf)
        {
            entranceUIObj.SetActive(false);
            isUIActive = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !entranceUIObj.activeSelf)
        {
            if(creditsUIObj.activeSelf)
            {
                SetCreditsUIActivity();
            }
            else
            {
                isUIActive = !isUIActive;
                mainUIObj.SetActive(isUIActive);
            }
        }
    }

    public void PlayButtonSound()
    {
        MainSoundController.instance.Play(buttonClickSound);
    }

    public void SetCreditsUIActivity()
    {
        isCreditsUIActive = !isCreditsUIActive;
        creditsUIObj.SetActive(isCreditsUIActive);
        mainUIObj.SetActive(!isCreditsUIActive);
    }
}