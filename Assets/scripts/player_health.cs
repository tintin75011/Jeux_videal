using UnityEngine;
using System.Collections;

public class player_health : MonoBehaviour
{
	public int max_Health = 100;
	public int current_Health;

	public bool is_Invincible = false;
	public float invincible_flash_delay = 0.2f;
	public float invicibility_Time=2f;

	public health_Bar health_Bar;
	public SpriteRenderer graphics;

    // Start is called before the first frame update
    void Start()
    {
        current_Health = max_Health; // define the max health value
		health_Bar.Set_Max_Health(max_Health); // assigne to the health bar
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.H)){
			Take_Damage(20);
		}
    }

	public void Take_Damage(int Damage){
		if(is_Invincible == false){
			current_Health -= Damage;
			health_Bar.Set_Health(current_Health);
			is_Invincible = true;
			StartCoroutine(Invincibility_Flash());
			StartCoroutine(Handle_Invicibillity_Deley());
		}

	}

	public IEnumerator Invincibility_Flash(){
		while(is_Invincible){
			graphics.color = new Color(1f,1f,1f,0f);
			yield return new WaitForSeconds(invincible_flash_delay);
			graphics.color = new Color(1f,1f,1f,1f);
			yield return new WaitForSeconds(invincible_flash_delay);


		}
	}

	public IEnumerator Handle_Invicibillity_Deley(){
		yield return new WaitForSeconds(invicibility_Time);
		is_Invincible = false;
	}
}
