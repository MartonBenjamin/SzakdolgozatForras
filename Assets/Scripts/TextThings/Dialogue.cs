using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Így kívülről is lehet értéket adni neki
public class Dialogue
{
    public string name;

    [TextArea(2,10)]
    public string[] sentences;

}
