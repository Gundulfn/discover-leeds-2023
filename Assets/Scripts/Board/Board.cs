using UnityEngine;
using System;
using System.Collections.Generic;

public class Board: MonoBehaviour
{
    private static Renderer rend;
    private static List<GameObject> splashes = new List<GameObject>();

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if(rend.material.color != ColorSettings.boardColor)
        {
            rend.material.color = ColorSettings.boardColor;
        }
    }

    public static void AddSplash(GameObject splash)
    {
        splashes.Add(splash);
    }

    public static void ClearBoard()
    {
        int count = splashes.Count;
        for(int i = 0; i < count; i++)
        {
            Destroy(splashes[0]);
            splashes.RemoveAt(0);
        }
    }
}