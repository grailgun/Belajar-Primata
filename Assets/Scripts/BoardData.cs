using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Board Game/Board Data")]
public class BoardData : ScriptableObject
{
    public List<string> data = new List<string>();
}
