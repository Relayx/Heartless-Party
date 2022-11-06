using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Code.Infrastructure
{
    public class LevelGenerator
    {
        [SerializeField] private Vector2Int mapSize = new Vector2Int(15, 15);
        [SerializeField] private Vector2Int startRoom = new Vector2Int(7, 7);
        [SerializeField] private Vector2Int distanceBetweenRooms = new Vector2Int(10, 10);

        public Room[,] rooms;

        private Vector2Int[] directions = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };

        public LevelGenerator()
        {
            rooms = new Room[mapSize.x, mapSize.y]; 
        }

        public void Generate(List<Room> roomPrefabs, int count)
        {
            Vector2Int roomSize = roomPrefabs[0].Size;
            rooms[startRoom.x, startRoom.y] = Object.Instantiate(roomPrefabs[0]);
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
                            rooms[neighbour.x, neighbour.y] = 
                                Object.Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
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