using UnityEngine;
using UnityEngine.UI;



public class inventary : MonoBehaviour
{
	public int coins_Count;
	public Text coin_Count_Text;
	public static inventary instance;
	
	void Awake(){
		if(instance != null){
			Debug.LogWarning("il y a plusieurs inventaire");
			return;
		}
		instance = this;
		coins_Count = 0;
		coin_Count_Text.text = coins_Count.ToString();
	}

	public void Add_Coins(int count){
		coins_Count += count;
		coin_Count_Text.text = coins_Count.ToString();
	}
}
