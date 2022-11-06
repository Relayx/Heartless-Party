using System.Collections.Generic;
using ModestTree;
using UnityEditor;
using UnityEngine;

namespace Code.Level
{
    public class LevelGenerator
    {
        [SerializeField] private Vector2Int mapSize = new Vector2Int(15, 15);
        [SerializeField] private Vector2Int startRoom = new Vector2Int(7, 7);
        [SerializeField] private Vector2Int distanceBetweenRooms = new Vector2Int(10, 10);

        public Room[,] rooms;
        public Vector2Int MapSize => mapSize;

        private Vector2Int[] directions = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };

        public LevelGenerator()
        {
            rooms = new Room[mapSize.x, mapSize.y]; 
        }

        public void Generate(List<Room> roomPrefabs, LevelService.Chances chances, int count)
        {
            Vector2Int roomSize = roomPrefabs[0].Size;
            rooms[startRoom.x, startRoom.y] = Object.Instantiate(roomPrefabs[0]); // TODO: Добавить начальную комнату
            rooms[startRoom.x, startRoom.y].transform.position = Vector3.zero;

            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(new Vector2Int(7, 7));
            int currentCount = 0;
            while (currentCount < count)
            {
                foreach (var curRoom in queue.ToArray())
                {
                    foreach (var direction in directions)
                    {
                        Vector2Int neighbour = curRoom + direction;
                        if (GenerationRule(neighbour))
                        {
                            currentCount++;
                            queue.Enqueue(neighbour);
                            rooms[neighbour.x, neighbour.y] = Object.Instantiate(RandomRoom(roomPrefabs, chances));
                            Vector3 moveTo = Vector3WithDirection(direction, roomSize) + 
                                             Vector3WithDirection(direction, distanceBetweenRooms);
                            rooms[neighbour.x, neighbour.y].transform.position =
                                rooms[curRoom.x, curRoom.y].transform.position + moveTo;
                        }

                        if (currentCount == count)
                        {
                            break;
                        }
                    }

                    if (currentCount == count)
                    {
                        break;
                    }
                }
            }

            AddTransitions();
        }

        private Room RandomRoom(List<Room> roomPrefabs, LevelService.Chances chances)
        {
            List<Room> easyRooms = new List<Room>();
            List<Room> normalRooms = new List<Room>();
            List<Room> hardRooms = new List<Room>();
            foreach (var room in roomPrefabs)
            {
                if (room.CompareTag("EasyRoom"))
                {
                    easyRooms.Add(room);
                }
                if (room.CompareTag("NormalRoom"))
                {
                    normalRooms.Add(room);
                }
                if (room.CompareTag("HardRoom"))
                {
                    hardRooms.Add(room);
                }
            }

            int easyValue = (!easyRooms.IsEmpty() ? chances.easyLevel : 0);
            int normalValue = (!easyRooms.IsEmpty() ? chances.easyLevel : 0) +
                              (!normalRooms.IsEmpty() ? chances.normalLevel : 0);
            int allChance = (!easyRooms.IsEmpty() ? chances.easyLevel : 0) +
                            (!normalRooms.IsEmpty() ? chances.normalLevel : 0) +
                            (!hardRooms.IsEmpty() ? chances.hardLevel : 0);
            int value = Random.Range(0, allChance);
            if (value < easyValue)
            {
                return easyRooms[Random.Range(0, easyRooms.Count)];
            }
            else if (value < normalValue)
            {
                return normalRooms[Random.Range(0, normalRooms.Count)];
            }
            else
            {
                return hardRooms[Random.Range(0, hardRooms.Count)];
            }
        }
        
        private static Vector3 Vector3WithDirection(Vector2Int direction, Vector2Int roomSize)
        {
            return new Vector3(direction.x * roomSize.x, direction.y * roomSize.y, 0);
        }

        private void AddTransitions()
        {
            // throw new System.NotImplementedException();
        }

        bool GenerationRule(Vector2Int index)
        {
            bool correctPlace = CorrectPlace(index);
            bool isEmpty = rooms[index.x, index.y] == null;
            int neighboursCount = 0;
            foreach (var direction in directions)
            {
                Vector2Int neighbour = index + direction;
                if (CorrectPlace(neighbour) && rooms[neighbour.x, neighbour.y] != null)
                {
                    neighboursCount++;
                }
            }

            bool lucky = (Random.value >= 0.5);
            return correctPlace && lucky && neighboursCount == 1 && isEmpty;
        }

        private bool CorrectPlace(Vector2Int index)
        {
            return 0 <= index.x && index.x < mapSize.x && 0 <= index.y && index.y < mapSize.y;
        }
    }
}