using System;
using System.Collections.Generic;

namespace OOAP5;

class Human : Warrior
{
    public const int minDefense = 435;
    public const int minStrength = 95;

    public Human(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

class Orc : Warrior
{
    public const int minDefense = 570;
    public const int minStrength = 150;

    public Orc(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

class Troll : Warrior
{
    public const int minDefense = 600;
    public const int minStrength = 135;

    public Troll(string name) : base(name)
    {
        InitStats(minDefense, minStrength);
    }
}

abstract class Warrior
{
    public virtual int CurrDef { get; set; }
    public virtual int CurrStrength { get; protected set; }
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
    protected void InitStats(int minDefense, int minStrength)
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
        this.CurrDef = warrior.CurrDef;
        this.CurrStrength = warrior.CurrStrength;
        this.Name = warrior.Name;
    }
}

class Archer : WarriorDecorator
{
    public const int BowPower = 205;
    public Archer(Warrior archer) : base(archer)
    {
        this.CurrStrength += BowPower;
    }
}

class Swordsman : WarriorDecorator
{
    public const int SwordPower = 230;

    public Swordsman(Warrior swordsman) : base(swordsman)
    {
        this.CurrStrength += SwordPower;
    }
}

class Maceman : WarriorDecorator
{
    public const int MacePower = 175;

    public Maceman(Warrior maceman) : base(maceman)
    {
        this.CurrStrength += MacePower;
    }
}

class Shielder : WarriorDecorator
{
    public Shielder(Warrior shielder) : base(shielder)
    {
    }
}

class WarriorFacade
{
    public Warrior Warrior { get; private set; }

    public void PickNameAndRace(string race, string name) => Warrior = race switch
    {
        "Human" => new Human(name),
        "Troll" => new Troll(name),
        "Orc" => new Troll(name),
        _ => new Human(name),
    };

    public void PickWeapon(string weapon) => Warrior = weapon switch
    {
        "Bow" => new Archer(Warrior),
        _ => new Archer(Warrior),
    };

    public void AddArmor(int armor = 0)
    {
        Warrior.CurrDef += armor;
    }

    public void AddShield(int armor = 0)
    {
        //TODO: Wrap Warrior into Shielder decorator
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