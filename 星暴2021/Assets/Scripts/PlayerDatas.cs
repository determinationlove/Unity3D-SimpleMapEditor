using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerDatas : MonoBehaviour
{
    [SerializeField]
    private string Id;
    [SerializeField]
    private string Name;
    [SerializeField]
    private string Skill;

    public void SetId(string _id)
    {
        Id = _id;
    }

    public void SetName(string _name)
    {
        Name = _name;
    }

    public void SetSkill(string _skill)
    {
        Skill = _skill;
    }

    public string GetId()
    {
        return Id;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetSkill()
    {
        return Skill;
    }

    public void SetDatas(string _id, string _name, string _skill)
    {
        Id = _id;
        Name = _name;
        Skill = _skill;
    }
}

