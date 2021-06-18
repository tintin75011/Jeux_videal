using UnityEngine;

public class player_shield : MonoBehaviour
{
	public int current_Shield;
	public int max_Shield;

	public shield_bar shield_Bar;
    // Start is called before the first frame update
    void Start()
    {
        current_Shield = max_Shield;

		shield_Bar.Set_Max_Shield(current_Shield);
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Y))
		Take_Shield_Damage(20);

    }

	public void Take_Shield_Damage(int Damage){
		current_Shield -= Damage;
		shield_Bar.Set_Shield(current_Shield);
	}

}
