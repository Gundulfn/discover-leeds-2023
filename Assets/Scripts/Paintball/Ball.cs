using UnityEngine;

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
        Board.AddSplash(splash);

        Destroy(gameObject);
    }
}