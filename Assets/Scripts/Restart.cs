using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Destroy(otherObj.gameObject);
        }
    }

}
