using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace WargameSystem.MenuSystem{
    public class MainUIManager : MonoBehaviour
    {
        public void ChangeScene(string name){
            SceneManager.LoadScene(name);
        }

        public void QuitGame(){
            // 해당 씬 종료.
            Application.Quit();
        }
    }
}