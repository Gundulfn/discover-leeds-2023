using UnityEngine;
using TMPro;

public class GunModel: MonoBehaviour
{
    private static GameObject modelObj;
    public Renderer gunColorRenderer;
    
    void Start()
    {
        modelObj = gameObject;
    }

    void Update()
    {
        if(gunColorRenderer.material.color != ColorSettings.splashColor)
        {
            gunColorRenderer.material.color = ColorSettings.splashColor;
        }
    }

    // Button Func
    public void SetGunVisibility(TextMeshProUGUI text)
    {
        modelObj.SetActive(!modelObj.activeSelf);

        if(modelObj.activeSelf)
        {
            text.SetText("Hide Gun");
        }
        else
        {
            text.SetText("Unhide Gun");
        }
    }
}