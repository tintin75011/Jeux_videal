using UnityEngine;

public class player_movement : MonoBehaviour {
	public float move_speed;
	public Rigidbody2D rigid_body; // adds physics body
	public bool is_jumping = false;
	public float jump_force;
	private Vector3 velocity = Vector3.zero;

	void Start() {

	}

	void Update() {
		if (Input.GetButtonDown("Jump")) { // spacebar
		  	is_jumping = true;
		}
	}

	void FixedUpdate() {
		float horizontal_movement = Input.GetAxis("Horizontal") * move_speed * Time.deltaTime; // time.deltatime => time since trigger key

		MovePlayer(horizontal_movement);
	}

	void MovePlayer(float _horizontal_movement) {
		Vector3 target_velocity = new Vector2(_horizontal_movement, rigid_body.velocity.y);
		rigid_body.velocity = Vector3.SmoothDamp(rigid_body.velocity, target_velocity, ref velocity, 0.05f);

		if (is_jumping == true) {
			rigid_body.AddForce(new Vector2(0f, jump_force));
			is_jumping = false;
		}
	}
}
