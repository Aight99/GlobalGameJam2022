using System;

public interface ISkill
{
    public int Damage { get; set; }
    public Action Effect { get; set; }  // Hack
}