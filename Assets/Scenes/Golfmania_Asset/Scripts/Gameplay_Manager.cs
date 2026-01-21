using System.Data;
using UnityEngine;

public class Gameplay_Manager : MonoBehaviour
{
    public Transform golfball;
    private SpherePhysics spherePhysics;

    public Transform club;

    public int limitCameraDistance = 1;

    private GameObject player;
    public GameObject golfBall_camera;


    private int howManyHit;
    private Vector3 lastHitPosition;
    private bool gotHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("XR Origin (XR Rig)");
        spherePhysics = golfball.gameObject.GetComponent<SpherePhysics>();

        lastHitPosition = golfball.position;
        gotHit = false;

        player.SetActive(true);
        golfBall_camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        bool isMoving = spherePhysics.IsMoving();
        float distance = Vector3.Distance(golfball.position, club.position);

        if (!gotHit && distance >= limitCameraDistance && isMoving)
        {
            player.SetActive(false);
            golfBall_camera.SetActive(true);
            gotHit = true;
        }

        if (gotHit && !isMoving)
        {
            player.transform.position = golfball.position + new Vector3(5.5f, 10f, 3.5f);
            player.SetActive(true);
            golfBall_camera.SetActive(false);
            gotHit = false;
        }

        if (golfball.position.y < -10f || Vector3.Distance(golfball.position, club.position) >= 1000f)
        {
            golfball.position = lastHitPosition;
            spherePhysics.ResetAllVelocities();
        }
    }

    public void AddHit()
    {
        howManyHit++;
    }

    public void Set_LastHitTime(Vector3 pos)
    {
        this.lastHitPosition = pos;
    }

    public void StopGame()
    {
        spherePhysics.ResetAllVelocities();
    }
}
