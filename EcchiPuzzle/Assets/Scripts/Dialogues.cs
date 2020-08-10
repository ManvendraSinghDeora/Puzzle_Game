using System;
using UnityEngine;

[Serializable]
public class Dialogues
{
    public string _name;
    [TextArea(2,10)]
    public string[] _dialogue;
}
