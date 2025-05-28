using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private bool grounnded;
    public ScoreSystem ScoreSystem;
    public int coinvalue = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.38128f, 0.38128f, 0.38128f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.38128f, 0.38128f, 0.38128f);

        if (Input.GetKey(KeyCode.Space) && grounnded == true)
            Jump();
            
        anim.SetBool("Run",horizontalInput !=0 );
        anim.SetBool("Grounded",grounnded);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        anim.SetTrigger("Jump");
        grounnded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounnded = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            ScoreSystem.ChangeScore(coinvalue);
        }
    }
}
