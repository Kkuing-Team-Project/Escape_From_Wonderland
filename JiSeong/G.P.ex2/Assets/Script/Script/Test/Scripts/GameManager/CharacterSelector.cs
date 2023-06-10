using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelector : MonoBehaviour
{
    public List<Kkuing> characterList;
    public static CharacterSelector instance;
    public int characterNum;

    private void Awake() {
        if(CharacterSelector.instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == "Game") Instantiate(characterList[CharacterSelector.instance.characterNum]);
    }
    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
