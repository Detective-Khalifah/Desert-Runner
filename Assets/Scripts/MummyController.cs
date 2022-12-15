using UnityEngine;
using System.Collections;

public class MummyController : MonoBehaviour 
{

	public GameObject james;

	public float jumpSpeed = 600.0f;
	public bool grounded = false;
	public bool doubleJump = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Animator anim;
	public Rigidbody rb;
	public float vSpeed;

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
		james = GameObject.Find("Player James (Default)");
		anim.SetBool("isIdle", true);
	}
	void Start ()
	{
		
	}
	void FixedUpdate () 
	{
		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		// vSpeed = rb.velocity.y;
        anim.SetFloat ("vSpeed", vSpeed);
	}
	void Update () 
	{
		Vector3 lookDirection = (james.transform.position - transform.position).normalized;
		rb.AddForce(lookDirection * vSpeed * Time.deltaTime);
		// anim.SetBool("isRun", true);
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
	}

	/*private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player James (Default)")
		{
			Debug.Log("You hit the Mummy. Game Over!");
			GameManager.gameOver = false;
		}
	}*/

}
