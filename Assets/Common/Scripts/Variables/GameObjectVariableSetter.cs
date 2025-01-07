using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Variables
{
    public class GameObjectVariableSetter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObjectVariable _gameObjectVariable;

        public void SetGameObjectVariable()
        {
            _gameObjectVariable.SetValue(gameObject);
        }
    }
}

