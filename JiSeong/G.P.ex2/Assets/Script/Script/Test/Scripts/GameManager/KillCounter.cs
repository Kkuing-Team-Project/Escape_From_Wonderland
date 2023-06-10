using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;
    public int ailenKill=0;
    public int meteorKill=0;
    
    private void Awake() {
        if(KillCounter.instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == "Game") {
            ailenKill=0;
            meteorKill=0;
        }
    }
}
