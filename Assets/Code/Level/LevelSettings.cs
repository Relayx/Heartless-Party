using System.Collections.Generic;
using Code;
using Code.Level;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 1)]
public class LevelSettings : ScriptableObject
{
    public List<Room> roomPrefabs;
    public LevelService.Chances chances;
    public int roomsCount;
}
