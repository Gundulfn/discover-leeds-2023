using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Camera persCam;
    public GameObject ballPrefab;
    public Transform bulletSpawn;
    public AudioClip fireSound;

    private FireMode fireMode;
    private bool isSingleShot;

    private float fireCooldown, currentCooldown;
    private const float SLOW_FIRE_COOLDOWN = .5f;
    private const float FAST_FIRE_COOLDOWN = .1f;

    RaycastHit hit;

    void Start()
    {
        fireMode = GetComponent<FireMode>();
    }

    void Update()
    {
        if(!UIHandler.IsUIActive)
        {
            isSingleShot = fireMode.currentFireModeNo == FireModeSettings.SINGLE_SHOT_NO;

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
                    if(fireMode.currentFireModeNo == FireModeSettings.SLOW_SHOT_NO)
                    {
                        fireCooldown = SLOW_FIRE_COOLDOWN;
                    }
                    else
                    {
                        fireCooldown = FAST_FIRE_COOLDOWN;
                    }

                    if(currentCooldown > 0)
                    {
                        currentCooldown -= Time.deltaTime;
                    }

                    if(Input.GetMouseButton(0))
                    {
                        Fire(pos);
                        return;
                    }
                }
            }

            MainSoundController.instance.StopLoop();
        }
    }

    void Fire(Vector3 pos)
    {
        if(currentCooldown <= 0 || isSingleShot)
        {
            GameObject ball = Instantiate(ballPrefab, bulletSpawn.position, Quaternion.identity);
            ball.GetComponent<Ball>().SetTargetPosition(pos);

            currentCooldown = fireCooldown;

            if(fireCooldown == SLOW_FIRE_COOLDOWN)
            {
                MainSoundController.instance.PlayImmediately(fireSound);
                MainSoundController.instance.StopLoop();
            }
            else
            {
                MainSoundController.instance.PlayLoop(fireSound);
                MainSoundController.instance.ContinueLoop();
            }
        }
    }
}