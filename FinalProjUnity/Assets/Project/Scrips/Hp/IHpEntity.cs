using System;

namespace Project.Scrips.Hp
{
    public interface IHpEntity
    {
        //event that activte on any health Change
        event Action Updated;
        //value of the healthPoints
        int Value { get; set; }
        
        void Increase(int value);
        void Decrease(int value);
    }
}