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

class ArmedWarrior : WarriorDecorator
{
    public ArmedWarrior(Warrior archer, int weaponPower = 0) : base(archer) { this.CurrStrength += weaponPower; }
}

class Shielder : WarriorDecorator
{
    public int AttackBlocks { get; private set; }

    public Shielder(Warrior shielder, int attackBlocks) : base(shielder) { AttackBlocks = attackBlocks; }
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
        "Bow" => new ArmedWarrior(Warrior, WeaponsPower.Bow),
        "Sword" => new ArmedWarrior(Warrior, WeaponsPower.Sword),
        "Mace" => new ArmedWarrior(Warrior, WeaponsPower.Mace),
        "Dagger" => new ArmedWarrior(Warrior, WeaponsPower.Dagger),
        "Axe" => new ArmedWarrior(Warrior, WeaponsPower.Axe),
        _ => new ArmedWarrior(Warrior),
    };

    static class WeaponsPower
    {
        public const int Bow = 245;
        public const int Sword = 270;
        public const int Mace = 190;
        public const int Dagger = 225;
        public const int Axe = 310;
    }

    public void PickArmor(int armor = 0) => Warrior.CurrDef += armor;

    public void PickShield(int attackBlocks = 0) => Warrior = new Shielder(Warrior, attackBlocks);
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