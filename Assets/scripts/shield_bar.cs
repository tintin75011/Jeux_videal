using UnityEngine;
using UnityEngine.UI;

public class shield_bar : MonoBehaviour
{
	public Slider slider;

	public Gradient gradient;
	public Image fill;

    public void Set_Max_Shield(int shield){

		slider.maxValue = shield;
		slider.value = shield;
		fill.color = gradient.Evaluate(1f);

	}

	public void Set_Shield(int shield){

		slider.value = shield;
		fill.color = gradient.Evaluate(slider.normalizedValue);

	}

}
