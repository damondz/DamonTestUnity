using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof (Rigidbody2D))]

public class PlatformControl : MonoBehaviour {
	public float maxSpeed = 10f; 
	bool facingLeft = true; 
	float fPlayerVelocityX;
    float fPlayerVelocityY;
    public bool CanDig;
	Animator anim; 
	Rigidbody2D rbPlayer;

    float moveH;
    float moveV;

	// Use this for initialization
	void Start ()
    {
        RespawnPlayer();

        anim = GetComponent<Animator>(); 
		rbPlayer = GetComponent<Rigidbody2D>(); 
	}

	void FixedUpdate ()
    { 
		moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        anim.SetFloat("Speed",Mathf.Abs(moveH));

        fPlayerVelocityX = rbPlayer.velocity.x;
        fPlayerVelocityY = rbPlayer.velocity.y;

        MovePlayer();

		if(moveH>0 && facingLeft) 
		{ 
			Flip(); 
		} 
		if(moveH<0 && !facingLeft) 
		{ 
			Flip(); 
		} 
	}

    private void MovePlayer()
    {
        if ((fPlayerVelocityX > -maxSpeed && moveH < 0) || (fPlayerVelocityX < maxSpeed && moveH > 0))
        {
            rbPlayer.AddForce(Vector2.right * moveH * maxSpeed * 3);
        }
        if ((fPlayerVelocityY > -maxSpeed && moveV < 0) || (fPlayerVelocityY < maxSpeed && moveV > 0))
        {
            rbPlayer.AddForce(Vector2.right * moveH * maxSpeed * 3);
        }
    }

    void Update() 
	{ 
		if(Input.GetButton("Digg")) 
		{
            StartCoroutine(StartDigging());
            //jumping = true; rbPlayer.AddForce(Vector2.up * jumpHeight); 
		} 
        if (Input.GetButtonDown("Refresh"))
        {
            RespawnPlayer();
        }
	}

    public void RespawnPlayer()
    {
        transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    private IEnumerator StartDigging()
    {
        Vector2 direction = new Vector2(moveH,moveV);
        Vector2 ShootStart = new Vector2(GetComponent<SpriteRenderer>().bounds.extents.x,
            GetComponent<SpriteRenderer>().bounds.extents.y);
        RaycastHit2D[] tileTargets = Physics2D.RaycastAll(transform.position, direction);
        foreach (RaycastHit2D tita in tileTargets)
        {
            GameObject tt = tita.transform.gameObject;
            if (tt && (tt.tag == "Core" || tt.tag == "Top"))
            {
                anim.SetBool("Digging", true);
                yield return new WaitForSeconds(1.5f);
                Destroy(tt);
                print(anim.GetBool("Digging"));
                MovePlayer();
                anim.SetBool("Digging", false);
                break;
            }
        }
    }

    void Flip() 
	{ 
		facingLeft = !facingLeft; 
		transform.localScale = new Vector3(transform.localScale.x*-1f,transform.localScale.y,transform.localScale.z); 
	} 
}
