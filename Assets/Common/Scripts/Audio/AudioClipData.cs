using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    [CreateAssetMenu(fileName = "AudioClipData", menuName = ("Sick Lab/Audio/Audio Clip Data"))]
    public class AudioClipData : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] AudioClip _audioClip;
        [Range(0f, 1f)]
        [SerializeField] float _volume = 0.5f;

        public AudioClip AudioClip => _audioClip;
        public float Volume => _volume;
    }
}