using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    public class SFXHandler : AAudioHandler
    {
        Coroutine _sfxFadeOutCoroutine;

        public void PlaySFX(AudioClipData audioClipData)
        {
            if (!_hasAudioSource) return;
            if (_audioSource == null)
            {
                Debug.LogWarning("No audio source");
                return;
            }
            float volume = _audioSetting.Volume * audioClipData.Volume;
            _audioSource.PlayOneShot(audioClipData.AudioClip, volume);
        }

        public void PlaySFX(AudioSource audioSource, AudioClipData audioClipData)
        {
            if (!_hasAudioSource) return;
            if (!_audioSetting.IsEnabled) return;
            float volume = _audioSetting.Volume * audioClipData.Volume;
            audioSource.volume = volume;
            audioSource.clip = audioClipData.AudioClip;
            audioSource.Play();
        }

        public void FadeOutSFX(AudioSource audioSource, float duration)
        {
            if (!_hasAudioSource) return;
            if (_sfxFadeOutCoroutine != null)
            {
                _audioManager.StopCoroutine(_sfxFadeOutCoroutine);
            }
            _sfxFadeOutCoroutine = _audioManager.StartCoroutine(FadeOutSFXCoroutine(audioSource, duration));
        }

        IEnumerator FadeOutSFXCoroutine(AudioSource audioSource, float duration)
        {
            float startVolume = audioSource.volume;
            float t = 0;

            while (t < duration)
            {
                t += UnityEngine.Time.deltaTime;
                audioSource.volume = Mathf.Lerp(startVolume, 0f, t / duration);
                yield return null;
            }

            audioSource.volume = 0f;
        }
    }
}

