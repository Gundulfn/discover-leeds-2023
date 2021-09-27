using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera persCam;
    public GameObject ballPrefab;
    public Renderer gunColorRenderer;
    public Transform bulletSpawn;

    private int currentFireModeNo;
    private bool isSingleShot;
    
    private float fireCooldown, currentCooldown;
    private const float SLOW_FIRE_COOLDOWN = 1;
    private const float FAST_FIRE_COOLDOWN = .1f;

    RaycastHit hit;

    void Start()
    {
        currentFireModeNo = 1;
        fireCooldown = SLOW_FIRE_COOLDOWN;
    }

    void Update()
    {
        if(gunColorRenderer.material.color != Ball.splashColor)
        {
            gunColorRenderer.material.color = Ball.splashColor;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            SetFireMode(false);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            SetFireMode(true);
        }

        if(Physics.Raycast(persCam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, -.01f);
            transform.LookAt(pos);

            if(isSingleShot)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Fire(pos);
                }
            }
            else
            {
                if(currentCooldown > 0)
                {
                    currentCooldown -= Time.deltaTime;
                }

                if(Input.GetMouseButton(0) && currentCooldown <= 0)
                {
                    Fire(pos);
                    currentCooldown = fireCooldown;
                }
            }
        }
    }

    void Fire(Vector3 pos)
    {
        GameObject ball = Instantiate(ballPrefab, bulletSpawn.position, Quaternion.identity);
        ball.GetComponent<Ball>().SetTargetPosition(pos);
    }

    public void SetFireMode(bool isIncreasing)
    {
        currentFireModeNo += (isIncreasing? 1: -1);

        if(currentFireModeNo < 0)
        {
            currentFireModeNo += 3;
        }

        currentFireModeNo %= 3;
        currentCooldown = 0;

        if(currentFireModeNo == 0)
        {
            isSingleShot = true;
        }
        else if(currentFireModeNo == 1)
        {
            isSingleShot = false;  
            fireCooldown = SLOW_FIRE_COOLDOWN;
        }
        else
        {
            fireCooldown = FAST_FIRE_COOLDOWN;
            isSingleShot = false;  
        }
    }
}