using UnityEngine;
using System.Collections;

public class AISimple : MonoBehaviour
{

    private RaycastHit HitPoint;
    private float MoveTo = 1;
    private int One = 1;
    public float MoveSpeed = 0.01f;
    public float MaxSpeed = 7;

    void Start()
    {
        MoveTo = MoveSpeed;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) < MaxSpeed)
            GetComponent<Rigidbody>().AddForce(MoveTo, 0, 0);
        var PosTMP = new Vector3(this.transform.position.x + One, this.transform.position.y, this.transform.position.z);
        Debug.DrawLine(this.transform.position, PosTMP);
        if (!Physics.Raycast(PosTMP, Vector3.down, out HitPoint, 1f))
        {
            if (MoveTo > 0)
            {
                MoveTo = -MoveSpeed;
                One = -1;
            }
            else
            {
                MoveTo = MoveSpeed;
                One = 1;
            }
        }
    }
}
