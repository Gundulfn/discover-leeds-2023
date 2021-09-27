using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSize : MonoBehaviour
{
    public Camera orthoCam;
    private const float SIZE_DIVISION = 10;

    void Start()
    {
        SetBoardSize();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetBoardSize();
        }
    }

    void SetBoardSize()
    {
        float height = orthoCam.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, 1, height) / SIZE_DIVISION;
    }
}