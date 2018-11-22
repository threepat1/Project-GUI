using UnityEngine;

using System.Collections;



public class Controller : MonoBehaviour
{
    [Header("MOVEMENT VARIABLES")]
    [Space(10)]
    [Header("Mini Header")]
    [Range(0f, 10f)]
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
        //single line comment
        /*
         multi
         line
         comment
         */
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
