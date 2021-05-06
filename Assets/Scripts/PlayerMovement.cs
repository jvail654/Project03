using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 20f;
    public float gravity = -9f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Camera camera1;
    [SerializeField] private Transform enemy;

    Vector3 velocity;
    bool isGrounded;

    private Transform target;
    [SerializeField] public Transform hitbox;

    private RaycastHit hit;

    public Transform MyTarget { get; set; }

    void Start()
    {

        target = GameObject.Find("Enemy").transform;
    }


    private bool InLineOfSight()
    {
        Vector3 targetDirec = (target.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, targetDirec, Vector3.Distance(transform.position, target.transform.position), 256))
        {
            if (hit.collider == null)
            {
                return true;
            }
        }

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirec, Vector3.Distance(transform.position, MyTarget.transform.position), 256);

        

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(1))
        {
            this.transform.LookAt(enemy);
            //PlaySong(m);
            this.transform.position = enemy.position;
        }


    }
}