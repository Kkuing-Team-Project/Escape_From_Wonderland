using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem{
    public class MainUIManager : MonoBehaviour
    {
        public AudioSource musicSource; // public input
        public Slider volumeSlider;

        public GameObject canvas;
        private bool isCanvasActive = false;
        private bool isGamePaused = false;

        private void Start()
        {
            // 슬라이더의 초기값 설정
            volumeSlider.value = musicSource.volume;

            // 슬라이더 값이 변경될 때 이벤트 처리
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        public void ChangeScene(string name){
            SceneManager.LoadScene(name);
        }

        public void QuitGame(){
            // 해당 씬 종료.
            Application.Quit();
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
            musicSource.volume = volume;
        }
    }
}