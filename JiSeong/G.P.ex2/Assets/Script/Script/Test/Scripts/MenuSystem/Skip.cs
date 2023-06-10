using UnityEngine;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem
{
    public class Skip : MonoBehaviour
    {
        private float term = 0f;
        // Start is called before the first frame update
        public void ChangeScene(string name){
            Debug.Log("test");
            // 해당 스크립트를 넣은 오브젝트의 Inspector에 다음 씬을 이름 쓰기.
            SceneManager.LoadScene(name);
        }

        // Update is called once per frame
        void Update(){
            term += Time.deltaTime;
            if(term >= 15.0f) SceneManager.LoadScene("Choosing_Character");
        }
    }

}