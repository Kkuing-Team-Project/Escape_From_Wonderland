using UnityEngine;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem
{
    public class DieUI : MonoBehaviour
    {
        public void ChangeScene(string name)
        {
            // 해당 스크립트를 넣은 오브젝트의 Inspector에 다음 씬을 이름 쓰기.
            SceneManager.LoadScene(name);
        }
        
        public void QuitGame()
        {
            // 해당 씬 종료.
            Application.Quit();
        }
    }
}