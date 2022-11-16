using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Skill")]
public class Skill :ScriptableObject
{
    public string skillName;
    public int damage;
    public string Effect;

}
