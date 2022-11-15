using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        hf = moveDirection.x > 0.01f ? moveDirection.x : moveDirection.x < -0.01f ? 1 : 0;
        vf = moveDirection.y > 0.01f ? moveDirection.y : moveDirection.y < -0.01f ? 1 : 0;



        anim.SetFloat("Horizontal", hf);
        //anim.SetFloat("Vertical", moveDirection.z);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Speed", vf);        
    }

    void FixedUpdate()
    {
        Move();
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}

//Ref https://www.youtube.com/watch?v=u8tot-X_RBI
//https://weeklyhow.com/unity-top-down-character-movement/
