using UnityEngine;

public class player_movement : MonoBehaviour {
	public float move_speed;
	public float jump_force;

	public Rigidbody2D rigid_body; // adds physics body

	public bool is_jumping = false;
	public bool is_Grounded; // Variable which check if the player is touching the ground
	public int  jump_Number = 0; // Jump count

	private Vector3 velocity = Vector3.zero;

	public Transform ground_Check_Left;
	public Transform ground_Check_right;

	public Animator player_Animator;
	public SpriteRenderer sprite_Renderer; // Component representing the character

	void Start() {}

	void Update() {
		if (Input.GetButtonDown("Jump") && (jump_Number < 1)) { // spacebar
		  	is_jumping = true;
			jump_Number++;
		}
		if (is_Grounded) {
			jump_Number = 0;
		}
	}

	void FixedUpdate() {
		float horizontal_movement = Input.GetAxis("Horizontal") * move_speed * Time.deltaTime; // time.deltatime => time since trigger key

		is_Grounded = Physics2D.OverlapArea(ground_Check_Left.position, ground_Check_right.position); // OverlapArea creat a rectangular bewteen points in argument

		MovePlayer(horizontal_movement);

		Flip(rigid_body.velocity.x);

		float character_Velocity = Mathf.Abs(rigid_body.velocity.x); // Abs() return the absolute value
		player_Animator.SetFloat("Speed", character_Velocity);	// setfloat send to player_Animator the value
	}

	void MovePlayer(float _horizontal_movement) {
		Vector3 target_velocity = new Vector2(_horizontal_movement, rigid_body.velocity.y);
		rigid_body.velocity = Vector3.SmoothDamp(rigid_body.velocity, target_velocity, ref velocity, 0.05f);

		if (is_jumping == true) {
			rigid_body.AddForce(new Vector2(0f, jump_force));
			is_jumping = false;
		}
	}

	void Flip(float _velocity){ // check to return the character side animation
		if(_velocity > 0.1f){
			sprite_Renderer.flipX = false; // dont return the character side animation
		}
		else if(_velocity < -0.1f){
			sprite_Renderer.flipX = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){ // only when somethings go in the 2Dcollider
		if(collision.CompareTag("Snake")){ //check if it's the player
			rigid_body.AddForce(new Vector2(0f, jump_force));
		}
	}
}
