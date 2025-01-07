using SickLab.GameTime;
using SickLab.Services;
using SickLab.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.UI
{
    public class PausingPopupUI : PopupUI
    {
        GameTimeManager _timeManager;

        protected override void Awake()
        {
            _timeManager = ServiceManager.Instance.GetService<GameTimeManager>();

            base.Awake();
        }

        public override void ShowPopup()
        {
            base.ShowPopup();
            _timeManager.AddTimePauser();
        }

        public override void HidePopup()
        {
            base.HidePopup();
            _timeManager.RemoveTimePauser();
        }
    }
}

