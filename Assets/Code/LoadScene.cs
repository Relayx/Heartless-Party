using System.Collections;
using System.Collections.Generic;
using Code.Infrastructure;
using Unity.VisualScripting;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private List<Room> roomPrefabs;
    [SerializeField] private int roomCount = 10;
    void Start()
    {
        StartCoroutine(Scene());
    }

    IEnumerator Scene()
    {
        while (true)
        {
            var levelGenerator = new LevelGenerator();
            levelGenerator.Generate(roomPrefabs, roomCount);
            yield return new WaitForSeconds(0.3f);
            foreach (var room in levelGenerator.rooms)
            {
                if (room != null)
                {
                    Destroy(room.gameObject);
                }
            }
        }
    }
}
