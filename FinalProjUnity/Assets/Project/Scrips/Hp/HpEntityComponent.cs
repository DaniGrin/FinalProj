using System;
using UnityEngine;

namespace Project.Scrips.Hp
{
    public class HpEntityComponent : MonoBehaviour, IHpEntity
    {
        public event Action Updated;

        [SerializeField] private int _maxValue;
        private int _value;

        private void Awake()
        {
            Value = _maxValue;
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                Updated?.Invoke();
            }
        }

        public void Increase(int value)
        {
            int newValue = value + Value;

            Value = newValue > _maxValue ? _maxValue : newValue;
        }

        public void Decrease(int value)
        {
            int newValue = Value - value;

            Value = newValue < 0 ? 0 : newValue;
        }
    }
}