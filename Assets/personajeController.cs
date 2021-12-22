using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeController : MonoBehaviour
{
    private CharacterController character;

    private Animator animator;
    [SerializeField]
    public float movementSpeed, rotationSpeed, jumpSpeed, gravity;
    private Vector3 movementDirection = Vector3.zero;



    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        character.Move(inputMovement * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);
        if (Input.GetButton("Jump") && character.isGrounded)
        {
            movementDirection.y = jumpSpeed;
        }
        movementDirection.y -= gravity * Time.deltaTime;
        character.Move(movementDirection * Time.deltaTime);

        animator.SetBool("isRunning",Input.GetAxisRaw("Vertical")!=0);
        animator.SetBool("isJumping",!character.isGrounded);



    }
}
