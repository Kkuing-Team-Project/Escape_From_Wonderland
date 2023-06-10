using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Kkuing : MonoBehaviour
{
    public static Kkuing instance; // 인스턴트
    public Image damageImage; // 피 효과
    public Slider healthSlider; // HP 슬라이더
    public TextMeshProUGUI TextTime; // Time Text
    public Color flashColour = new Color(1f, 0f, 0f, 0.2f); // HP 효과 색상

    public int playerHp = 100;
    public int playerDmg = 10;
    public int playerSpd = 10;
    public float term = 60.0f; // 시간
    private int asteroidDmg = 20;
    private int alienDmg = 10;

    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Player HealthUI 게임 오브젝트를 생성합니다.
        GameObject HealthUI = new GameObject("HealthUI");

        // HealthUI 게임 오브젝트를 Canvas의 자식으로 설정합니다.
        HealthUI.transform.SetParent(GameObject.Find("Canvas").transform, false);

        // Image 컴포넌트를 생성하여 HealthUI의 자식으로 추가합니다.
        Image damageImages = Instantiate(damageImage, HealthUI.transform);

        // Slider 컴포넌트를 생성하여 HealthUI의 자식으로 추가합니다.
        Slider healthSliders = Instantiate(healthSlider, HealthUI.transform);

        TextMeshProUGUI TextTimes = Instantiate(TextTime, HealthUI.transform);
        TextTime.text = "Time: " + "60";
        damageImage.color = new Color(0f, 0f, 0f, 0f);
        healthSlider.value = playerHp;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * playerSpd, moveVertical * playerSpd);
        rb.velocity = movement;

        float clampedX = Mathf.Clamp(rb.position.x, -1000f, 1000f);
        float clampedY = Mathf.Clamp(rb.position.y, -1000f, 1000f);
        rb.position = new Vector2(clampedX, clampedY);

        term -= Time.deltaTime;
        TextMeshProUGUI TextTime = GameObject.Find("Time(Clone)").GetComponent<TextMeshProUGUI>();
        TextTime.text = "Time: " + term;
        if(term <= 0f) End();
    }
    void LateUpdate(){
        // 운석 리스트
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Asteroid");
        GameObject[] meteorites2 = GameObject.FindGameObjectsWithTag("Asteroid2");

        // 에일리언 리스트
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        GameObject[] aliens2 = GameObject.FindGameObjectsWithTag("Alien2");

        // 가장 가까운 오브젝트를 찾기 위한 변수 초기화
        float closestDistance = Mathf.Infinity;
        GameObject closestObject = null;

        // 운석 중 가장 가까운 오브젝트 탐색
        foreach (GameObject meteorite in meteorites)
        {
            float distance = Vector2.Distance(transform.position, meteorite.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = meteorite;
            }
        }

        // 운석 중 가장 가까운 오브젝트 탐색
        foreach (GameObject meteorite2 in meteorites2)
        {
            float distance = Vector2.Distance(transform.position, meteorite2.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = meteorite2;
            }
        }

        // 에일리언 중 가장 가까운 오브젝트 탐색
        foreach (GameObject alien in aliens)
        {
            float distance = Vector2.Distance(transform.position, alien.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = alien;
            }
        }

        // 에일리언 중 가장 가까운 오브젝트 탐색
        foreach (GameObject alien2 in aliens2)
        {
            float distance = Vector2.Distance(transform.position, alien2.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = alien2;
            }
        }

        if (closestObject != null)
        {
            // Player를 가장 가까운 오브젝트의 방향으로 회전시킴
            Vector2 objectDirection = closestObject.transform.position - transform.position;
            float angle = Mathf.Atan2(objectDirection.y, objectDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")){
            Destroy(collision.gameObject);
            TakeDamage(asteroidDmg);
            ActivateDamageImage();
        }

        if (collision.gameObject.CompareTag("Alien")){
            Destroy(collision.gameObject);
            TakeDamage(alienDmg);
            ActivateDamageImage();
        }
    }

    private void ActivateDamageImage()
    {
        Image damageImage = GameObject.Find("Damge(Clone)").GetComponent<Image>();
    
        if (damageImage != null){
            damageImage.color = flashColour; // 데미지를 입으면 붉은색 화면
            StartCoroutine(DelayedDisableDamageImage());
        }
    }

    private IEnumerator DelayedDisableDamageImage() // 코루틴
    {
        Image damageImage = GameObject.Find("Damge(Clone)").GetComponent<Image>();
        yield return new WaitForSeconds(0.5f);

        damageImage.color = new Color(0f, 0f, 0f, 0f);
    }

    private void TakeDamage(int damageAmount)
    {
        playerHp -= damageAmount;
        Slider loadedHealthSlider = GameObject.Find("HealthSlider(Clone)").GetComponent<Slider>();

        if (playerHp <= 0){
            SceneManager.LoadScene("Die");
            if (loadedHealthSlider != null) loadedHealthSlider.value = 100; // 로드된 씬에서 healthSlider를 찾아 값을 설정합니다.
        }
        else loadedHealthSlider.value = playerHp;
    }

    private void End(){
        // Instantiate()
        SceneManager.LoadScene("Ending");
    }
}
