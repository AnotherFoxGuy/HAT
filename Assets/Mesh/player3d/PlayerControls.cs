using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    public float moveSpeed = 0.5f;

    private Animator animator;
    private Vector3 movement;


    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

        transform.position += movement * moveSpeed;

        if (movement.x != 0 || movement.z != 0)
        {

            animator.SetBool("isRunning", true);

        }
        else
            animator.SetBool("isRunning", false);

    }
}
