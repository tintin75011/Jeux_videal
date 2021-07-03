using UnityEngine;

public class pickUp_object : MonoBehaviour
{
	public GameObject object_To_Destroy;
	private void OnTriggerEnter2D(Collider2D collision){
		player_shield player_shield = collision.transform.GetComponent<player_shield>();

		if(collision.CompareTag("Player")){
			player_shield.current_Shield += 10;
			player_shield.shield_Bar.Set_Shield(player_shield.current_Shield);
			Destroy(object_To_Destroy);
		}

	}
}
