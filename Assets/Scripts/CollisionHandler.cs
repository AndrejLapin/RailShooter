using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player has died");
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath"); // calling this function in PlayerController.cs
        StartCoroutine(RestartLevelAfterDelay());
    }

    IEnumerator RestartLevelAfterDelay()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        sceneLoader.LoadLevelOne();
    }
}
