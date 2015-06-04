using UnityEngine;
using System.Collections;

public class TurnScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody playerrigidbody;
    private bool rotateworld = false;
    private bool stoprotateworld = false;
    private float worldrotate = 0;
    private float rotspeed = 0;
    private Vector3 rotpointcenter;
    private RaycastHit hitpointfront;
    private RaycastHit hitpointback;
    public float rotatespeed = 1.5f;
    private GameObject skybox;
    private GameObject level;


    void Start()
    {
        player = GameObject.Find("Player");
        playerrigidbody = player.GetComponent<Rigidbody>();
        skybox = GameObject.Find("skybox");
        level = GameObject.Find("level");
        skybox.transform.position = new Vector3(skybox.transform.position.x, skybox.transform.position.y, level.transform.position.z);
    }

    void Update()
    {
        var PosTMPFront = new Vector3(player.transform.position.x + playerrigidbody.velocity.x / 4, player.transform.position.y - 2, player.transform.position.z - 100);
        var PosTMPBack = new Vector3(player.transform.position.x + playerrigidbody.velocity.x / 4, player.transform.position.y - 2, player.transform.position.z + 100);
        //Debug.DrawLine(player.transform.position, PosTMPFront);
        if (Physics.Raycast(PosTMPFront, Vector3.forward, out hitpointfront, 300f) && !rotateworld)
        {
            Debug.DrawLine(player.transform.position, hitpointfront.point);
            if (hitpointfront.point.z > player.transform.position.z)
            {
                //print("HitPointFront");
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, hitpointfront.point.z + 0.2f);
            }
        }
        if (Physics.Raycast(PosTMPBack, Vector3.back, out hitpointback, 300f) && !rotateworld)
        {
            Debug.DrawLine(player.transform.position, hitpointback.point);
            if (hitpointback.point.z < player.transform.position.z)
            {
                //print("HitPointBack");
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, hitpointback.point.z - 0.2f);
            }
        }
        if (Input.GetButtonDown("TurnLeft") && !rotateworld)
        {
            rotateworld = true;
            worldrotate = Mathf.Repeat(worldrotate + 90, 360);
            rotspeed = rotatespeed;
        }
        if (Input.GetButtonDown("TurnRight") && !rotateworld)
        {
            rotateworld = true;
            worldrotate = Mathf.Repeat(worldrotate - 90, 360);
            rotspeed = -rotatespeed;
        }
        if (rotateworld)
        {
            Time.timeScale = 0;
            Debug.DrawLine(Vector3.zero, player.transform.position);
            transform.RotateAround(player.transform.position, Vector3.up, rotspeed);
            skybox.transform.position = new Vector3(skybox.transform.position.x, skybox.transform.position.y, level.transform.position.z);
        }
        if (transform.eulerAngles.y > worldrotate - 0.1 && transform.eulerAngles.y < worldrotate + 0.1)
        {
            if (stoprotateworld)
            {
                rotateworld = false;
                stoprotateworld = false;
                this.transform.eulerAngles = new Vector3(Mathf.Round(this.transform.eulerAngles.x), Mathf.Round(this.transform.eulerAngles.y), Mathf.Round(this.transform.eulerAngles.z));
                Time.timeScale = 1;
            }
        }
        if (this.transform.eulerAngles.y < worldrotate - 2 || this.transform.eulerAngles.y > worldrotate + 2)
        {
            stoprotateworld = true;
        }
    }
}
