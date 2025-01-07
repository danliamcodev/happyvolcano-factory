using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.GameTime
{
    public class GameTimeManager
    {
        float _normalTimeScale = 1f;
        float _timeScale;
        int _timePausers = 0;

        public void SetGameTimeScale(float p_timeScale)
        {
            Time.timeScale = p_timeScale;
            _timeScale = p_timeScale;
        }

        public void ReturnNormalTime()
        {
            Time.timeScale = _normalTimeScale;
            _timeScale = _normalTimeScale;
        }

        public void AddTimePauser()
        {
            _timePausers++;
            Time.timeScale = 0f;
        }

        public void RemoveTimePauser()
        {
            _timePausers--;
            if (_timePausers <= 0)
            {
                _timePausers = 0;
                Time.timeScale = _timeScale;
            }
        }

        public void ForceResumeTime()
        {
            _timePausers = 0;
            Time.timeScale = _timeScale;
        }
    }

}