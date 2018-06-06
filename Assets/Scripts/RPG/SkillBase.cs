using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Attribute
{
    Fire,
    Water,
    Earth
}

public struct SkillBase 
{
    private string skillName;
    private Attribute attribute;
    private int skillDamage;

    public void SetSkillInfo(string skillName, string attribute, int skillDamage)
    {
        this.skillName = skillName;
        this.attribute = (Attribute)System.Enum.Parse(typeof(Attribute), attribute);
        this.skillDamage = skillDamage;
    }


}


