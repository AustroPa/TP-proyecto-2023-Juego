﻿
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;


    private void Awake() {

        // AGARRAR VALORES DE EL RIGIDBODY Y LAS ANIMACIONES DE OBJETOS
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    
    }


    private void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
        //  body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);




        // DAR VUELTA PJ CUANDO SE MUEVE
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
        /*
        if (Input.GetKey(KeyCode.Space) && isGrounded()) {

        Jump();

        }
        */


        // SETEAR LOS PARAMETROS DEL ANIMACIONES
        anim.SetBool("run",horizontalInput != 0 /* en vez de hacer el if */);
        anim.SetBool("grounded", isGrounded());



        // WallJump logic
        if (wallJumpCooldown > 0.2f)
        {

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;

            }
            else { body.gravityScale = 5; }

            if (Input.GetKey(KeyCode.Space))
            { Jump(); }
        
        }
        else {
            wallJumpCooldown += Time.deltaTime;
        }

    }
    
    private void Jump() {
        if (isGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded() ) {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10  /* fuerza con la que se despega */, 0 /* distancia de salto de pared */);

                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3  /* fuerza con la que se despega */, 6 /* distancia de salto de pared */);
            }
            wallJumpCooldown = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {


    }

    private bool isGrounded(){

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer) ;
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack() {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

}
