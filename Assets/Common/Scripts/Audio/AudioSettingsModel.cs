using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    [System.Serializable]
    public class AudioSettingsModel
    {
        [SerializeField] AudioSetting _bgm;
        [SerializeField] AudioSetting _sfx;
        [SerializeField] AudioSetting _tts;

        public AudioSetting BGM => _bgm;
        public AudioSetting SFX => _sfx;
        public AudioSetting TTS => _tts;

        public AudioSettingsModel()
        {
            _bgm = new AudioSetting();
            _sfx = new AudioSetting();
            _tts = new AudioSetting();
        }

        public void TransferSettings(AudioSettingsModel model)
        {
            _bgm.TransferSettings(model.BGM);
            _sfx.TransferSettings(model.SFX);
            _tts.TransferSettings(model.TTS);
        }
    }
}
