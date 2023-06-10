using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Planet : MonoBehaviour
{
    public int PlanetHp = 10000;
    //public Slider loadedPlanetHPSlider; // HP 슬라이더
    private int asteroidDmg = 20;
    private int alienDmg = 10;

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("Asteroid2")){
            Destroy(other.gameObject);
            TakeDamage(asteroidDmg);
        }

        if (other.gameObject.CompareTag("Alien2")){
            Destroy(other.gameObject);
            TakeDamage(alienDmg);
        }
    }

     private void TakeDamage(int damageAmount)
    {
        PlanetHp -= damageAmount;
        Debug.Log(PlanetHp);
        Slider loadedPlanetHPSlider = GameObject.Find("planet_Slider").GetComponent<Slider>();

        if (PlanetHp <= 0){
            SceneManager.LoadScene("Die");

            // 로드된 씬에서 healthSlider를 찾아 값을 설정합니다.
            if (loadedPlanetHPSlider != null){
                loadedPlanetHPSlider.value = 100;
            }
        }
        else {
            loadedPlanetHPSlider.value = PlanetHp;
        }
    }
}
