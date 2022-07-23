using System;

namespace Project.Scrips.Hp
{
    public interface IHpEntity
    {
        event Action Updated;
        
        int Value { get; set; }
        
        void Increase(int value);
        void Decrease(int value);
    }
}