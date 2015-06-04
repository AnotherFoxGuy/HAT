using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody player_meshrigidbody;
    private GameObject player_mesh;
    private RaycastHit HitPoint;
    private string LastClip;
    public float MaxSpeed = 7;
    private int CoinsFound = 0;
    private GameObject Skybox;
    private Animator animator;


    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
        player_meshrigidbody = this.GetComponent<Rigidbody>();
        player_mesh = GameObject.Find("PlayerMesh");
        player_mesh.transform.eulerAngles = new Vector3(0, 90, 0);
        GameObject[] coinsInLevelTotal;
        coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
        print("coinsInLevelTotal = " + coinsInLevelTotal.Length);
        Skybox = GameObject.Find("skybox");
    }

    void Update()
    {
        Skybox.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Skybox.transform.position.z);
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(this.transform.position, Vector3.down, 1.5f))
                player_meshrigidbody.AddForce(transform.TransformDirection(Vector3.up * 400));
        }
        if (Physics.Raycast(this.transform.position, Vector3.down, 1.25f))
        {
            if (Input.GetButton("Right") || Input.GetButton("Left"))
                animator.SetInteger("State", 1);
            else
                animator.SetInteger("State", 0);
        }

        else
        {
            animator.SetInteger("State", 2);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetButton("Right"))
        {
            player_mesh.transform.eulerAngles = new Vector3(0, 90, 0);
            if (player_meshrigidbody.velocity.x < MaxSpeed)
                player_meshrigidbody.AddForce(transform.TransformDirection(Vector3.right * 20));
        }
        if (Input.GetButton("Left"))
        {
            player_mesh.transform.eulerAngles = new Vector3(0, 270, 0);
            if (player_meshrigidbody.velocity.x > -MaxSpeed)
                player_meshrigidbody.AddForce(transform.TransformDirection(Vector3.left * 20));
        }
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "Coin")
        {
            Destroy(otherObj.gameObject);
            CoinsFound++;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 50, 150, 25), "Coins collected: " + CoinsFound);
    }
}
