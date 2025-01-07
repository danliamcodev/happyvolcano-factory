using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SickLab.Audio;
using SickLab.Levels;

namespace SickLab.UI.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] AudioClipData _bgmClipData;

        private void Start()
        {
            AudioManager.Instance.BGMHandler.PlayBGM(_bgmClipData);
        }
    }
}