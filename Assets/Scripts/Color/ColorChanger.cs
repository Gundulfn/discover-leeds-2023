using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public HSVPicker.ColorPicker colorPicker;
    public Color selectedButtonColor, unselectedButtonColor;
    public Button splashColorButton, boardColorButton;

    private const int SPLASH_ID = 0;
    private const int BOARD_ID = 1;
    private int targetObjId;

    void Start()
    {
        ColorSettings.Initialize();
        
        splashColorButton.onClick.AddListener(() => SetId(SPLASH_ID));
        boardColorButton.onClick.AddListener(() => SetId(BOARD_ID));


        colorPicker.onValueChanged.AddListener(color =>
        {
            switch(targetObjId)
            {
                case SPLASH_ID:
                    ColorSettings.SetSplashColor(color);
                    break;
                case BOARD_ID:
                    ColorSettings.SetBoardColor(color);
                    break;
                default:
                    break;        
            }
        });
    }

    private void SetId(int value)
    {
        targetObjId = value;

        if(value == SPLASH_ID)
        {
            splashColorButton.GetComponent<Image>().color = selectedButtonColor;
            boardColorButton.GetComponent<Image>().color = unselectedButtonColor;

            colorPicker.CurrentColor = ColorSettings.splashColor;
        }
        else
        {
            splashColorButton.GetComponent<Image>().color = unselectedButtonColor;
            boardColorButton.GetComponent<Image>().color = selectedButtonColor;

            colorPicker.CurrentColor = ColorSettings.boardColor;
        }
    }

    //Fun part
    public static Color GetRandomColor()
    {
        System.Random random = new System.Random();
        float r = (float)(random.NextDouble() * (1 - 0) + 0);
        float g = (float)(random.NextDouble() * (1 - 0) + 0);
        float b = (float)(random.NextDouble() * (1 - 0) + 0);

        return new Color(r, g, b);
    }
}