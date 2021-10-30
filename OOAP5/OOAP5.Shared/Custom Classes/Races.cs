using System.Collections.Generic;

namespace OOAP5;

class Human : Warrior
{
    public const float minDef = 31.4f;
    public const float minStrength = 9.5f;
}

class Orc : Warrior
{
    public const float minDef = 40.6f;
    public const float minStrength = 15.1f;
}

class Troll : Warrior
{
    public const float minDef = 43.7f;
    public const float minStrength = 13.7f;
}

abstract class Warrior
{
    public float CurrDef { get; set; }
    public float Name { get; set; }
}

public class ViewModelClass
{
    public List<dynamic> Data { get; }
    public ViewModelClass() => Data = new List<dynamic>
        {
            new { Race = typeof(Human).Name, Defense = Human.minDef, Strength = Human.minStrength},
            new { Race = typeof(Troll).Name, Defense = Troll.minDef, Strength = Troll.minStrength},
            new { Race = typeof(Orc).Name, Defense = Orc.minDef, Strength= Orc.minStrength}
        };
}