using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_patrol : MonoBehaviour
{
	public float speed;
	public Transform[] way_Points;

	private Transform target;
	private int dest_Point = 0;

	public SpriteRenderer sprite_Renderer_Snake; // Component representing the character

    // Start is called before the first frame update
    void Start()
    {
        target = way_Points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 	// Translate() est la version la plus basique de déplacement, on lui donne un Vector3. normalized signifie que le vecteur à toujour 1 comme normalized

		if(Vector3.Distance(transform.position, target.position) < 0.3f){
			dest_Point = (dest_Point + 1) % way_Points.Length;
			target = way_Points[dest_Point];
			sprite_Renderer_Snake.flipX = !sprite_Renderer_Snake.flipX;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.transform.CompareTag("Player")){
			player_health player_health = collision.transform.GetComponent<player_health>();
			player_shield player_shield = collision.transform.GetComponent<player_shield>();

			if(player_shield.current_Shield > 0){
				player_shield.Take_Shield_Damage(10);
			} else {
				player_health.Take_Damage(10);
			}

		}
	}

}
