using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public static bool isUIActive
    {
        get;
        private set;
    }

    public GameObject mainUIObj, gunModelObj;
    public AudioClip buttonClickSound;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isUIActive = !isUIActive;
            mainUIObj.SetActive(isUIActive);
        }
    }

    public void PlayButtonSound()
    {
        MainSoundController.instance.Play(buttonClickSound);
    }

    public void SetGunVisibility(TextMeshProUGUI text)
    {
        gunModelObj.SetActive(!gunModelObj.activeSelf);

        if(gunModelObj.activeSelf)
        {
            text.SetText("Hide Gun");
        }
        else
        {
            text.SetText("Unhide Gun");
        }
    }
}