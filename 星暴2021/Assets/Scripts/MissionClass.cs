using UnityEngine;
using System;
using System.Collections.Generic;

public class MissionClass : MonoBehaviour
{
    [SerializeField]
    private string Id;
    [SerializeField]
    private string Name;
    [SerializeField]
    private string Content;


    public void SetId(string _id)
    {
        Id = _id;
    }

    public void SetName(string _name)
    {
        Name = _name;
    }

    public void SetContent(string _content)
    {
        Content = _content;
    }

    public string GetId()
    {
        return Id;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetContent()
    {
        return Content;
    }

    public void SetDatas(string _id, string _name, string _content)
    {
        Id = _id;
        Name = _name;
        Content = _content;
    }
}