using UnityEngine;

public class pick_up_coins : MonoBehaviour
{
	public GameObject coin;

    private void OnTriggerEnter2D(Collider2D collision){

		Debug.Log("oui");
		
		if(collision.CompareTag("Player")){
			Destroy(coin);

		}
	}

}
