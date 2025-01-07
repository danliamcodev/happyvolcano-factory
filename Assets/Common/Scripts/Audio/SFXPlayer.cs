using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Audio
{
    public class SFXPlayer : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] AudioClipData _audioClipData;

        public void PlaySFX()
        {
            AudioManager.Instance.SFXHandler.PlaySFX(_audioClipData);
        }
    }

}
