using UnityEngine;
using System.Collections;

public class TurnScript : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody PlayerRigidbody;
    private bool RotateWorld = false;
    private bool StopRotateWorld = false;
    private float WorldRotate = 0;
    private float RotSpeed = 0;
    private Vector3 RotPointCenter;
    private RaycastHit HitPointFront;
    private RaycastHit HitPointBack;
    public float RotateSpeed = 1.5f;
    private GameObject Skybox;
    private GameObject Level;


    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
        Skybox = GameObject.Find("Skybox");
        Level = GameObject.Find("Level");
        Skybox.transform.position = new Vector3(Skybox.transform.position.x, Skybox.transform.position.y, Level.transform.position.z);
    }

    void Update()
    {
        var PosTMPFront = new Vector3(Player.transform.position.x + PlayerRigidbody.velocity.x / 4, Player.transform.position.y - 2, Player.transform.position.z - 100);
        var PosTMPBack = new Vector3(Player.transform.position.x + PlayerRigidbody.velocity.x / 4, Player.transform.position.y - 2, Player.transform.position.z + 100);
        //Debug.DrawLine(Player.transform.position, PosTMPFront);
        if (Physics.Raycast(PosTMPFront, Vector3.forward, out HitPointFront, 300f) && !RotateWorld)
        {
            Debug.DrawLine(Player.transform.position, HitPointFront.point);
            if (HitPointFront.point.z > Player.transform.position.z)
            {
                //print("HitPointFront");
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, HitPointFront.point.z + 0.2f);
            }
        }
        if (Physics.Raycast(PosTMPBack, Vector3.back, out HitPointBack, 300f) && !RotateWorld)
        {
            Debug.DrawLine(Player.transform.position, HitPointBack.point);
            if (HitPointBack.point.z < Player.transform.position.z)
            {
                //print("HitPointBack");
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, HitPointBack.point.z - 0.2f);
            }
        }
        if (Input.GetButtonDown("TurnLeft") && !RotateWorld)
        {
            RotateWorld = true;
            WorldRotate = Mathf.Repeat(WorldRotate + 90, 360);
            RotSpeed = RotateSpeed;
        }
        if (Input.GetButtonDown("TurnRight") && !RotateWorld)
        {
            RotateWorld = true;
            WorldRotate = Mathf.Repeat(WorldRotate - 90, 360);
            RotSpeed = -RotateSpeed;
        }
        if (RotateWorld)
        {
            Time.timeScale = 0;
            Debug.DrawLine(Vector3.zero, Player.transform.position);
            transform.RotateAround(Player.transform.position, Vector3.up, RotSpeed);
            Skybox.transform.position = new Vector3(Skybox.transform.position.x, Skybox.transform.position.y, Level.transform.position.z);
        }
        if (transform.eulerAngles.y > WorldRotate - 0.1 && transform.eulerAngles.y < WorldRotate + 0.1)
        {
            if (StopRotateWorld)
            {
                RotateWorld = false;
                StopRotateWorld = false;
                this.transform.eulerAngles = new Vector3(Mathf.Round(this.transform.eulerAngles.x), Mathf.Round(this.transform.eulerAngles.y), Mathf.Round(this.transform.eulerAngles.z));
                Time.timeScale = 1;
            }
        }
        if (this.transform.eulerAngles.y < WorldRotate - 2 || this.transform.eulerAngles.y > WorldRotate + 2)
        {
            StopRotateWorld = true;
        }

    }

}
