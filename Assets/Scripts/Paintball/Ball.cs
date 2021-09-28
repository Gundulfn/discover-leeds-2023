using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public GameObject splashPrefab;
    
    private Renderer rend;

    private Rigidbody rb;
    private Vector3 targetPos;

    public void SetTargetPosition(Vector3 value)
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        targetPos = value;
        rb.AddForce((value - transform.position) * 500);

        rend.material.color = ColorSettings.splashColor;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject splash = Instantiate(splashPrefab, targetPos, splashPrefab.transform.rotation);
        splash.GetComponent<Renderer>().material.color = ColorSettings.splashColor;
        splash.transform.rotation = Quaternion.Euler(GetRandomRotation(), splash.transform.rotation.eulerAngles.y, 
                                                                          splash.transform.rotation.eulerAngles.z);
        Board.AddSplash(splash);

        Destroy(gameObject);
    }

    private float GetRandomRotation()
    {
        return UnityEngine.Random.Range(0, 360);
    }
}