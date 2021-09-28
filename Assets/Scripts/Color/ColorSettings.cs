using UnityEngine;

public static class ColorSettings
{
    private static Color defaultSplashColor = Color.red;
    private static Color defaultBoardColor = Color.white;

    public static void Initialize()
    {
        splashColor = defaultSplashColor;
        boardColor = defaultBoardColor;
    }

    public static Color splashColor
    {
        get;
        private set;
    }

    public static Color boardColor
    {
        get;
        private set;
    }

    public static void SetSplashColor(Color value)
    {
        splashColor = value;
    }

    public static void SetBoardColor(Color value)
    {
        boardColor = value;
    }
}