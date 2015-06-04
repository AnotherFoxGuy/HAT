using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour
{

    private GameObject Player;
    private Rigidbody PlayerRigidbody;
    private float Timer = Mathf.Infinity;
    private bool win = false;
    private GameObject[] coinsInLevelTotal;


    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time > Timer)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (win)
        {
            PlayerRigidbody.isKinematic = true;
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Time.deltaTime, Player.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
            print("coins left = " + coinsInLevelTotal.Length);
            win = true;
            Timer = Time.time + 2;
        }
    }

    void OnGUI()
    {
        if (win)
        {
            GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 5 - 25, 150, 50), "Win !!\n coins left = " + coinsInLevelTotal.Length);
        }
    }
}

