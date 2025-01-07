using UnityEngine;

namespace SickLab.Audio
{
    public class AudioHandlerFactory
    {
        public virtual T Create<T>(AudioManager audioManager, AudioSetting audioSetting, AudioSource audioSource) where T : AAudioHandler, new()
        {
            T instance = new T();
            instance.Initialize(audioManager, audioSetting, audioSource);
            return instance;
        }
    }
}
