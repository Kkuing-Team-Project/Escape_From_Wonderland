using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace WargameSystem.MenuSystem
{
    public class SettingsUIManager : MonoBehaviour
    {
        public AudioMixer masterMixer; // public input
        public float masterLvl;

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
            masterMixer.SetFloat("Volume", volume); // volume 조절
        }
    }
}