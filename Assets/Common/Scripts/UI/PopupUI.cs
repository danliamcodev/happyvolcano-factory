using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.UI
{
    public class PopupUI : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] GameObject _view;

        protected virtual void Awake()
        {
            HidePopup();
        }

        public virtual void ShowPopup()
        {
            _view.SetActive(true);
        }

        public virtual void HidePopup()
        {
            _view.SetActive(false);
        }
    }
}
