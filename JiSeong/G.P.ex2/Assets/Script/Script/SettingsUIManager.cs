using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem
{
    public class SettingsUIManager : MonoBehaviour
    {
        public AudioSource musicSource; // public input
        public Slider volumeSlider;

        public GameObject canvas;
        private bool isCanvasActive = false;
        private bool isGamePaused = false;

        private void Start()
        {
            if (musicSource != null)
            {
                // 음악 소스가 할당된 경우에만 초기화
                musicSource.Play();
            }
            else
            {
                Debug.LogError("음악 오디오 소스가 할당되지 않았습니다.");
            }
            
            // 슬라이더의 초기값 설정
            volumeSlider.value = musicSource.volume;

            // 슬라이더 값이 변경될 때 이벤트 처리
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isCanvasActive) CloseCanvas();
                else OpenCanvas();
            }
        }

        public void OpenCanvas()
        {
            canvas.SetActive(true);
            isCanvasActive = true;
            PauseGame();
        }

        public void CloseCanvas()
        {
            canvas.SetActive(false);
            isCanvasActive = false;
            ResumeGame();
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
            isGamePaused = true;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            isGamePaused = false;
        }

        public void ChangeScene(string name){
            SceneManager.LoadScene(name);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen; // Screen size setting
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex); // 인덱스 번 
        }

        public void SetVolume(float volume)
        {
            // 슬라이더 값을 음악 소스의 볼륨에 적용
            if (musicSource != null)
            {
                musicSource.volume = volume;
            }
            else
            {
                Debug.LogError("음악 오디오 소스가 할당되지 않았습니다.");
            }
        }
    }
}
