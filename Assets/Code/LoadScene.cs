using System.Collections;
using System.Collections.Generic;
using Code;
using Code.Infrastructure;
using Code.Level;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class LoadScene : MonoBehaviour
{
    private LevelService levelService;
    [SerializeField] private LevelSettings levelSettings;
    
    [Inject]
    public void Constructor(LevelService service)
    {
        levelService = service;
    }
    
    void Start()
    {
        StartCoroutine(Scene());
    }

    IEnumerator Scene()
    {
        while (true)
        {
            levelService.LevelGenerate(levelSettings);
            yield return new WaitForSeconds(3f);
            levelService.DeleteLevel();
        }
    }
}
