using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = transform.parent.GetComponent<Slider>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = slider.value + "%";
    }
}
