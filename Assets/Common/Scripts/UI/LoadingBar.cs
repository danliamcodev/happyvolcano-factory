using UnityEngine;
using UnityEngine.UI;

namespace SickLab.UI.Elements
{
    public class LoadingBar : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Slider _slider;

        public void ProgressLoadingBar(float p_progress)
        {
            _slider.value = p_progress;
        }
    }
}