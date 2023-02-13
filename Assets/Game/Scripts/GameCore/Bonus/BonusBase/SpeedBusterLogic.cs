using UnityEngine;
using System;
using System.Collections;
namespace BonusBase 
{
    public class SpeedBusterLogic
    {
        readonly int durationTime;
        readonly float speedBustMultiplier;
        public event Action OnBonusUsed = delegate { };
        public event Action OnBonusStopped = delegate { };
        public SpeedBusterLogic(int durationTime,float speedBustMultiplier) 
        {
            this.durationTime = durationTime;
            this.speedBustMultiplier = speedBustMultiplier;
        }
        public IEnumerator BonusPlayingTime() 
        {
            OnBonusUsed?.Invoke();
            yield return new WaitForSeconds(durationTime);
            OnBonusStopped?.Invoke();
        }
        public float ChangeMoveSpeed(float moveSpeed) 
        {
           return moveSpeed *= speedBustMultiplier;
        }
    }
}
