using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderGroup : MonoBehaviour {
		
	public delegate void UpdateValue(float value);
	public UpdateValue updateValue;
	
	private Slider slider;
	private Text sliderText;
	private Text valueText;
	
	private float value;
	
	void Awake () {
		slider = GetComponentInChildren<Slider>();
		
		Text[] texts = GetComponentsInChildren<Text>();
		for (int i = 0; i < texts.Length; i++)
		{
			if (texts[i].gameObject.name == "SliderText")
			{
				sliderText = texts[i];
			}
			if (texts[i].gameObject.name == "ValueText")
			{
				valueText = texts[i];
			}
		}
	}
	
	public void SetUp (float v, UpdateValue m) {
		slider.onValueChanged.AddListener (delegate {UpdateLocalValue ();});
		
		value = v;
		slider.value = value;
		valueText.text = value.ToString();
		
		updateValue = m;
	}
	
	void UpdateLocalValue () {
		value = slider.value;
		if (valueText != null)
		{
			valueText.text = value.ToString();
		}
		
		if (updateValue != null)
		{
			updateValue(value);
		}
	}
}
