using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject splashPrefab;
    
    private Renderer rend;
    public static Color splashColor
    {
        get;
        private set;
    }

    private Rigidbody rb;
    private Vector3 targetPos;

    public void SetTargetPosition(Vector3 value)
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        splashColor = rend.material.color;

        targetPos = value;
        rb.AddForce((value - transform.position) * 500);

        splashColor = Board.GetRandomColor();
        rend.material.color = splashColor;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject splash = Instantiate(splashPrefab, targetPos, splashPrefab.transform.rotation);
        splash.GetComponent<Renderer>().material.color = splashColor;
        Board.AddSplash(splash);

        Destroy(gameObject);
    }
}