using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static bool isUIActive
    {
        get;
        private set;
    }

    public GameObject mainUIObj;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isUIActive = !isUIActive;
            mainUIObj.SetActive(isUIActive);
        }
    }
}