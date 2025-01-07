using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SickLab.Audio
{
    [Serializable]
    public class AudioSetting
    {
        [SerializeField] bool _isEnabled = true;
        [SerializeField] float _volume = 1;

        public Action SettingUpdated;

        public bool IsEnabled => _isEnabled;
        public float Volume
        {
            get
            {
                if (!_isEnabled) return 0f;
                return _volume;
            }
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
            SettingUpdated?.Invoke();
        }

        public void SetIsEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            Debug.Log("settings updated");
            SettingUpdated?.Invoke();
        }

        public void Toggle()
        {
            _isEnabled = !_isEnabled;
            SettingUpdated?.Invoke();
        }

        public AudioSetting()
        {
            _isEnabled = true;
            _volume = 0.5f;
        }

        public void TransferSettings(AudioSetting audioSettings)
        {
            SetVolume(audioSettings.Volume);
            SetIsEnabled(audioSettings.IsEnabled);
        }
    }
}
