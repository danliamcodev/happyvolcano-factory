using UnityEngine;
using UnityEngine.UI;
using SickLab.Variables;

namespace SickLab.UI.Elements
{
    public class SliderUI : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] FloatVariable _value;
        void Start()
        {
            GetComponent<Slider>().value = _value.value;
        }
    }
}