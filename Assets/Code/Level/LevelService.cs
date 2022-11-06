using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.Level
{
    public class LevelService
    {
        private LevelGenerator levelGenerator;
        
        public LevelService(LevelGenerator generator)
        {
            levelGenerator = generator;
        }
        
        public void LevelGenerate(LevelSettings levelSettings)
        {
            Chances chances = levelSettings.chances;
            if (chances.easyLevel < 0 || chances.normalLevel < 0 || chances.hardLevel < 0)
            {
                throw new System.Exception("Bad chances for rooms! (negative value)");
            }
            levelGenerator.Generate(levelSettings.roomPrefabs, chances, levelSettings.roomsCount);
        }

        public void DeleteLevel()
        {
            for (int i = 0; i < levelGenerator.MapSize.x; i++)
            for (int j = 0; j < levelGenerator.MapSize.y; j++)
            {
                if (levelGenerator.rooms[i, j] != null)
                {
                    Object.Destroy(levelGenerator.rooms[i, j].gameObject);
                    levelGenerator.rooms[i, j] = null;
                }
            }
        }

        public void LockAllDoors(Vector2Int roomIndex)
        {
            foreach (var door in (Door[]) Enum.GetValues(typeof(Enum)))
            {
                LockDoor(roomIndex, door);
            }
        }

        public void LockDoor(Vector2Int roomIndex, Door door)
        {
            throw new System.NotImplementedException();
        }

        public void UnlockDoor(Vector2Int roomIndex, Door door)
        {
            throw new System.NotImplementedException();
        }

        public enum Door
        {
            Left,
            Right,
            Top,
            Under
        }
        
        [Serializable]
        public class Chances
        {
            public int easyLevel = 1;
            public int normalLevel = 1;
            public int hardLevel = 1;
        }
    }
}