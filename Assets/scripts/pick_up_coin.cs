using UnityEngine;

public class pick_up_coin : MonoBehaviour
{
	public GameObject coin;
	public inventary inventary;
	private void OnTriggerEnter2D(Collider2D collision){

		if(collision.CompareTag("Player")){
			//inventary inventary = collision.transform.GetComponent<inventary>();
			Destroy(coin);
			inventary.Add_Coins(100);

		}

	}
}
