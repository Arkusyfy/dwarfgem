using UnityEngine;

public class move : MonoBehaviour
{
    private readonly float jumpSpeed = 900f;
    private readonly int staticSpeed = 10;
    private Animator anim;
    private bool canJump;
    private bool doLadder;
    private int facing = 1;

    public bool spadanie = false;

    public bool spad = false;

  
    // Start is called before the first frame update
    private Rigidbody rb;
    private float x, y, lad;

    private void Start()
    {
        anim = GetComponent<Animator>();
        canJump = true;
        rb = GetComponent<Rigidbody>();
        // rb.maxAngularVelocity=1f;
        doLadder = false;
    }

    // Update is called once per frame

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        lad = Input.GetAxisRaw("Vertical");
        y = Input.GetAxisRaw("Jump");


        if (x != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);
    }


    private void FixedUpdate()
    {
        var move = new Vector3(x, 0, 0);

        //transform.position += move * (staticSpeed * Time.fixedDeltaTime);
        rb.AddForce(move, ForceMode.VelocityChange);
        var clampedX = Mathf.Clamp(rb.velocity.x, -10, 10f);

        rb.velocity = new Vector3(clampedX, rb.velocity.y, rb.velocity.z);

        if (x > 0)
            facing = 1;
        else if (x < 0)
            facing = -1;

        var lScale = gameObject.transform.localScale;

        if (facing > 0)
            gameObject.transform.localScale = new Vector3(Mathf.Abs(lScale.x), lScale.y, lScale.z);
        else
            gameObject.transform.localScale = new Vector3(Mathf.Abs(lScale.x) * -1f, lScale.y, lScale.z);
        if (canJump && y > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            anim.Play("jump");
            rb.AddForce(0, jumpSpeed, 0);
            DisableJump();
        }

        // Debug.Log(doLadder);   

        if (doLadder)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.velocity += new Vector3(0, lad * 10, 0);
            // if (Mathf.Approximately(rb.velocity.x, 0))
            //     rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z); 
        }
        else
        {
            rb.useGravity = true;
        }

        if (!spadanie && rb.velocity.y <= -15.5f)
        {
            spadanie = true;
            anim.SetTrigger("spadanie");
            
            spad = false;
        }

        if (spad)
        {
            spad = false;
            spadanie = false;
            anim.SetTrigger("spad");
        }
        
    }

    public int GetFacing()
    {
        return facing;
    }

    public void EnableJump()
    {
        canJump = true;
    }

    public void DisableJump()
    {
        canJump = false;
    }

    public void SetLadder(bool state)
    {
        doLadder = state;
    }
}