using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 10f;
    float moveInput;
    // Transform trans;
    

    // for jump variables
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Transform feetpos;
     [SerializeField] float checkradius;
    bool isGrounded;
    [SerializeField] LayerMask what_is_ground;

    

    // for space hold jump
    [SerializeField] float jumpTimer = 2f;
    float jumpTimeCounter;
    bool isJumping;
    
    //for wall detect
    bool isStable; 
    
    
    // for ground detect
     BoxCollider2D col;
    [SerializeField] LayerMask jumpableGround;


    // for SFX
    [SerializeField] AudioClip shortJumpSound;
    [SerializeField] AudioClip longJumpSound;









     void Start() {
      rb = GetComponent<Rigidbody2D>();  
      col = GetComponent<BoxCollider2D>();
    //   trans= GetComponent<Transform>();


    

    }


    // FOR WALL GLITCH
    // private void OnCollisionEnter2D(Collision2D other) {
    //     float moveInput;
    //     moveInput = Input.GetAxis("Horizontal");
    //     if(other.gameObject.tag == "Wall"){
    //         if(moveInput<0)
    //         transform.Translate(new Vector3(5,0,0));
    //         // rb.AddForce(Vector2.right*50,0);


    //         if(moveInput>0)
    //         transform.Translate(new Vector3(-5,0,0));
    //         // rb.AddForce(Vector2.left*50,0);
            
    //         isStable =false;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other) {
    //     if(other.gameObject.tag == "Wall")
    //     isStable =true;
    // }

    

    private void Update() {
        
        
        
        moveInput = Input.GetAxis("Horizontal");

        // if(isStable)
        rb.velocity = new Vector2(moveInput*moveSpeed,rb.velocity.y);
            
            if(moveInput>0)
            transform.eulerAngles = new Vector3(0,0,0);

            else if(moveInput<0)
            transform.eulerAngles = new Vector3(0,180,0);

    

    

        // isGrounded = Physics2D.OverlapCircle(feetpos.position,checkradius,what_is_ground);
        isGrounded = checkGround();

        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            isJumping =true;
            jumpTimeCounter = jumpTimer;
            rb.velocity = Vector2.up*jumpForce;
            if(jumpTimeCounter==jumpTimer)
            GetComponent<AudioSource>().PlayOneShot(shortJumpSound);
        }
            if(Input.GetKey(KeyCode.Space) && isJumping){

            if( jumpTimeCounter>0){
            rb.velocity = new Vector2(moveInput*moveSpeed,1*jumpForce);

            // rb.velocity = Vector2.up*jumpForce;
            
                jumpTimeCounter-=Time.deltaTime;
                // if(jumpTimeCounter==0.2f)
                // GetComponent<AudioSource>().PlayOneShot(longJumpSound);
            }
            }
            else{
                isJumping =false;
            }

            if(Input.GetKeyUp(KeyCode.Space)){
                isJumping=false;
            }


    
    }

    bool checkGround(){
       return Physics2D.BoxCast(col.bounds.center,col.bounds.size,0,Vector2.down,0.1f,jumpableGround);
    }

    




        
}
