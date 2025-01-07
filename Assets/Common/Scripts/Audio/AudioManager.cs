using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    public class AudioManager : AMonoSingleton<AudioManager>
    {
        [Header("References")]
        [SerializeField] AudioSettingsModel _audioSettingsModel;
        [Header("Audio Sources")]
        [SerializeField] AudioSource _bgmSource;
        [SerializeField] AudioSource _sfxSource;
        //Audio Handlers
        BGMHandler _bgmHandler;
        SFXHandler _sfxHandler;

        public BGMHandler BGMHandler => _bgmHandler;
        public SFXHandler SFXHandler => _sfxHandler;

        protected override void Awake()
        {
            base.Awake();
            InitializeAudioManager();
        }

        private void OnEnable()
        {
            _audioSettingsModel.BGM.SettingUpdated += _bgmHandler.SetBGMSourceVolume;
        }

        private void OnDisable()
        {
            if (_bgmHandler != null) _audioSettingsModel.BGM.SettingUpdated -= _bgmHandler.SetBGMSourceVolume;
        }

        private void InitializeAudioManager()
        {
            InitializeAudioSettingsModel();
            CreateAudioHandlers();
        }

        private void InitializeAudioSettingsModel()
        {
            if (_audioSettingsModel == null)
            {
                _audioSettingsModel = new AudioSettingsModel();
            }
        }

        private void CreateAudioHandlers()
        {
            AudioHandlerFactory audioHandlerFactory = new AudioHandlerFactory();
            _bgmHandler = audioHandlerFactory.Create<BGMHandler>(this, _audioSettingsModel.BGM, _bgmSource);
            _sfxHandler = audioHandlerFactory.Create<SFXHandler>(this, _audioSettingsModel.SFX, _sfxSource);
        }
    }
}