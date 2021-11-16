using System.Collections.Generic;

namespace OOAP5;

class Human : Warrior
{
    public const float minDefense = 31.4f;
    public const float minStrength = 9.5f;

    public Human(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

class Orc : Warrior
{
    public const float minDefense = 40.6f;
    public const float minStrength = 15.1f;

    public Orc(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

class Troll : Warrior
{
    public const float minDefense = 43.7f;
    public const float minStrength = 13.7f;

    public Troll(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

abstract class Warrior
{
    public virtual float CurrDef { get; set; }
    public virtual float CurrStrength { get; set; }
    public virtual string Name { get; set; }

    public Warrior(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Initialize Warrior stats so, that Current Defense and Strength = Minimun Defense and Strength appropriate Warrior Race
    /// </summary>
    /// <param name="minDefense"></param>
    /// <param name="minStrength"></param>
    protected void InitStats(float minDefense, float minStrength)
    {
        CurrDef = minDefense;
        CurrStrength = minStrength;
    }

    public override string ToString() => $@"Name: {Name}
Defense: {CurrDef}
Strength: {CurrStrength}";

    public Warrior ShallowCopy() => (Warrior)MemberwiseClone();
}

abstract class WarriorDecorator : Warrior
{
    protected Warrior warrior;

    public WarriorDecorator(Warrior warrior) : base(warrior.Name)
    {
        this.warrior = warrior;
    }
}

class Archer : WarriorDecorator
{
    const float BowPower = 17.25f;
    public Archer(Warrior archer) : base(archer)
    {
        this.CurrStrength += BowPower;
    }
}

// presenting list, displaying with Syncfusion chart (histogram)
public class ViewModelClass
{
    public List<dynamic> Data { get; }
    public ViewModelClass() => Data = new List<dynamic>
        {
            new { Race = typeof(Human).Name, Defense = Human.minDefense, Strength = Human.minStrength},
            new { Race = typeof(Troll).Name, Defense = Troll.minDefense, Strength = Troll.minStrength},
            new { Race = typeof(Orc).Name, Defense = Orc.minDefense, Strength= Orc.minStrength}
        };
}