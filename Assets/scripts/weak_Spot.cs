using UnityEngine;

public class weak_Spot : MonoBehaviour
{
	public GameObject object_To_Destroy;

	private void OnTriggerEnter2D(Collider2D collision){ // only when somethings go in the 2Dcollider
		if(collision.CompareTag("Player")){ //check if it's the player

			Destroy(object_To_Destroy); // destroy the gameObject
			Debug.Log("touché");
		}
	}
}
