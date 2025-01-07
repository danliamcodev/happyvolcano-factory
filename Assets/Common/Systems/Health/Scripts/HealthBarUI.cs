using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SickLab.Systems.Health
{
    public class HealthBarUI : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] Image _trailImage;
        [SerializeField] Image _fillImage;
        [Header("Preferences")]
        [SerializeField] float _updateDuration = 0.2f;
        [SerializeField] float _trailDelay = 0.6f;
        [SerializeField] AnimationCurve _updateCurve;
        Coroutine _trailSequence;
        Tween _trailTween;
        Tween _fillTween;

        public void UpdateHealth(float currentHealth, float maxHealth)
        {
            UpdateFill(GetPctHealth(currentHealth, maxHealth));
            if (_trailSequence != null) StopCoroutine(_trailSequence);
            _trailSequence = StartCoroutine(nameof(UpdateTrailIE), GetPctHealth(currentHealth, maxHealth));
        }

        private void UpdateFill(float pctHP)
        {
            if (_fillTween != null) _fillTween.Kill();
            _fillTween = _fillImage.DOFillAmount(pctHP, _updateDuration)
                .SetEase(_updateCurve);
        }

        private IEnumerator UpdateTrailIE(float pctHP)
        {
            if (_trailTween != null) _trailTween.Kill();
            float trailTimer = _trailDelay;

            while(trailTimer > 0)
            {
                trailTimer -= Time.deltaTime;
                yield return null;
            }

            _trailTween = _trailImage.DOFillAmount(pctHP, _updateDuration)
                       .SetEase(_updateCurve);
        }

        private float GetPctHealth(float currentHelath, float maxHealth)
        {
            return currentHelath / maxHealth;
        }
    }
}