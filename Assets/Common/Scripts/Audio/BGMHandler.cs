using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    public class BGMHandler : AAudioHandler
    {
        AudioClipData _currentBGMData;
        Coroutine _bgmFadeCoroutine;

        public void PlayBGM(AudioClipData audioClipData, bool fresh = false)
        {
            if (!_hasAudioSource) return;
            if (!fresh && _audioSource.clip == audioClipData.AudioClip) return;
            _audioSource.clip = audioClipData.AudioClip;
            _audioSource.volume = _audioSetting.Volume * audioClipData.Volume;
            _audioSource.loop = true;
            _currentBGMData = audioClipData;
            _audioSource.Play();
        }

        public void FadeBGM(float value, float duration, bool isRealTime = true)
        {
            if (!_hasAudioSource) return;
            if (_bgmFadeCoroutine != null) _audioManager.StopCoroutine(_bgmFadeCoroutine);
            _bgmFadeCoroutine = _audioManager.StartCoroutine(IEFadeBGM(value, duration, isRealTime));
        }

        IEnumerator IEFadeBGM(float value, float duration, bool isRealTime)
        {
            float startVolume = _audioSource.volume;
            float t = 0;

            while (t < duration)
            {
                // Use unscaledDeltaTime if isRealTime is true, otherwise use deltaTime
                t += isRealTime ? Time.unscaledDeltaTime : Time.deltaTime;

                float normalizedTime = t / duration;
                _audioSource.volume = Mathf.Lerp(startVolume, value, normalizedTime)
                                      * _audioSetting.Volume
                                      * _currentBGMData.Volume;

                yield return null;
            }

        }

        public void SetBGMSourceVolume()
        {
            if (_currentBGMData == null) return;
            Debug.Log(_audioSetting.Volume);
            _audioSource.volume = _audioSetting.Volume * _currentBGMData.Volume;
        }
    }
}
