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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ClearBoard();
        }
    }

    public static void AddSplash(GameObject splash)
    {
        splashes.Add(splash);
        //rend.material.color = GetRandomColor();
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

    public static Color GetRandomColor()
    {
        System.Random random = new System.Random();
        float r = (float)(random.NextDouble() * (1 - 0) + 0);
        float g = (float)(random.NextDouble() * (1 - 0) + 0);
        float b = (float)(random.NextDouble() * (1 - 0) + 0);

        return new Color(r, g, b);
    }
}