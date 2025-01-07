using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    public class AAudioHandler
    {
        protected AudioManager _audioManager;
        protected AudioSetting _audioSetting;
        protected AudioSource _audioSource;

        protected bool _hasAudioSource { get 
            {  
                bool hasAudioSource = _audioSource != null;
                if (!hasAudioSource) Debug.LogWarning("No Audio Source");
                return hasAudioSource;
            } 
        }

        public virtual void Initialize(AudioManager audioManager, AudioSetting audioSetting, AudioSource audioSource)
        {
            _audioManager = audioManager;
            _audioSetting = audioSetting;
            _audioSource = audioSource;
        }

        public void AssignSettings(AudioSetting audioSetting)
        {
            _audioSetting = audioSetting;
        }
    }
}
