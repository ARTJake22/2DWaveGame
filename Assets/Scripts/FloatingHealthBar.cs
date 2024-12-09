using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;


    //updates the slider value to decrease when the gameObject its attached to takes damage.
    public void UpdateHealthBar(float currentValue, float maxValue){
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
