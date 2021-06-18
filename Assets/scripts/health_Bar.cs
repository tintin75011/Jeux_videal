using UnityEngine;
using UnityEngine.UI;

public class health_Bar : MonoBehaviour
{
    public Slider slider; // component representing the health bar

	public Gradient gradient;
	public Image fill; // image qui remplie notre bar de vie

	public void Set_Max_Health(int health){ // remet les pts de vie au max

		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f); // la couleur de notre fill correspond à la valeur maximale (1f) de notre gradient
	}

	public void Set_Health(int health){

		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue); // la couleur de notre fill correspond à la valeur de notre slider normalisé(vaeur transformé entre 0 et 1, exemple 50 => 0.5) 
	}
}
