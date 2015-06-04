using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    private GameObject ConstructionWorker;
    private RaycastHit HitPoint;
    private string LastClip;
    public float MaxSpeed = 7;
    private int CoinsFound = 0;
    private GameObject Skybox;


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

    void Start()
    {
        PlayerRigidbody = this.GetComponent<Rigidbody>();
        ConstructionWorker = GameObject.Find("ConstructionWorker");
        ConstructionWorker.transform.eulerAngles = new Vector3(0, 90, 0);
        GameObject[] coinsInLevelTotal;
        coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
        print("coinsInLevelTotal = " + coinsInLevelTotal.Length);
        Skybox = GameObject.Find("Skybox");
    }

    void Update()
    {
        Skybox.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Skybox.transform.position.z);
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(this.transform.position, Vector3.down, 1.5f))
                PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.up * 400));
        }
        if (Physics.Raycast(this.transform.position, Vector3.down, 1))
        {
            AnimateThis("idle", false);
            if (Input.GetButton("Right"))
                AnimateThis("run", false);
            else if (Input.GetButton("Left"))
                AnimateThis("run", false);
        }
        else
        {
            AnimateThis("jump_pose", true);
        }


    }

    void FixedUpdate()
    {
        if (Input.GetButton("Right"))
        {
            ConstructionWorker.transform.eulerAngles = new Vector3(0, 90, 0);
            if (PlayerRigidbody.velocity.x < MaxSpeed)
                PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.right * 20));
        }
        if (Input.GetButton("Left"))
        {
            ConstructionWorker.transform.eulerAngles = new Vector3(0, 270, 0);
            if (PlayerRigidbody.velocity.x > -MaxSpeed)
                PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.left * 20));
        }
    }

    void AnimateThis(string CurrentClip, bool Forced)
    {
        if (LastClip != CurrentClip)
        {
            if (Forced)
                ConstructionWorker.GetComponent<Animation>().Play(CurrentClip);
            else
                ConstructionWorker.GetComponent<Animation>().CrossFade(CurrentClip, 0.2f);
            LastClip = CurrentClip;
        }
    }

}
