using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadLevelOne", 2f);
        }
    }

    private void MakeSingleton()
    {
        int numSceneLoaders = FindObjectsOfType<SceneLoader>().Length;
        if (numSceneLoaders > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }
}
