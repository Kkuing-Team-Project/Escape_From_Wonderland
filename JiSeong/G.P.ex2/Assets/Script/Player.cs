using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    public GameObject[] PlayerUIHp;
    public Image teaCupImage;
    public Image hatImage;
    public Image timeImage;
    public Color flashColour = new Color(1f, 0f, 0f, 1f);

    public float speed;
    public int PlayerHp = 3;
    public int RabbitHp;
    public int RabbitDmg = 1;

    public Card attack;

    private Vector3 vector;
    private Animator animator;
    // private int currentWalkCount;
    private bool canMove = true;

    float timeImpactTimer = 0f;
    float jonyatimer = 0f;

    bool eatTime = false;
    bool defense = false;
    bool tea = false;

    bool tt = false;

    private Collider2D coll;
    public SpriteRenderer spriter;
    private Rigidbody2D rb;

    private float term = 0f;
    private int teaCupCount = 0;
    private int hatCount = 0;
    private int timeCount = 0;

    public int CardCountNull = 0;
    public int teaCupCountNull = 0;
    public int hatCountNull = 0;
    public int timeCountNull = 0;
    public int KillCountNull = 0;

    //public Animation Opening;
    public float PlayerSpeed = 3f;
    public int PlayGame = 0;


    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();

        //Opening = GetComponent<Animator>();
        transform.position = new Vector3(-48.69f, 0f, 0f);

        /*Image damageImage = GameObject.Find("Damge").GetComponent<Image>();
        damageImage.color = new Color(0f, 0f, 0f, 0f);*/

        Image damageImage = GameObject.Find("effect").GetComponent<Image>();
        damageImage.color = new Color(0f, 0f, 0f, 0f); 

        // TeaCup, Hat, Time 이미지를 70% 불투명하게 설정
        Color transparentColor = new Color(1f, 1f, 1f, 0.4f);

        teaCupImage.color = transparentColor;
        hatImage.color = transparentColor;
        timeImage.color = transparentColor; 
    }

    private void Update()
    {
        if (PlayGame == 0) {
            float moveSpeed = PlayerSpeed * Time.deltaTime;
            transform.Translate(moveSpeed, 0, 0);
            // animator.SetFloat("DirX", moveSpeed);
            animator.SetBool("Walking", true);
        }
        

        if(PlayGame != 0)
        {
            if (canMove)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    canMove = false;
                    StartCoroutine(MoveCoroutine());
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && !animator.GetCurrentAnimatorStateInfo(0).IsName("run attack"))
            {
                animator.SetTrigger("run attack");
                Instantiate(attack, transform.position, Quaternion.identity);
                CardCountNull += 1;
            }

            Color transparentColor = new Color(1f, 1f, 1f, 0.4f);

            if (eatTime && Input.GetKeyDown(KeyCode.E))
            {
                print("시계 사용");
                timeImpactTimer = 2;
                timeCount = 0; ;

                if (timeCount <= 0)
                {
                    timeImage.color = transparentColor;
                }
            }

            if (timeImpactTimer > 0)
            {
                timeImpactTimer -= Time.deltaTime;
                tt = true;
                SpriteRenderer playerimage = GameObject.Find("Player").GetComponent<SpriteRenderer>();
                playerimage.color = new Color(1f, 1f, 1f, 0.5f);
            }

            else
            {
                tt = false;
                SpriteRenderer playerimage = GameObject.Find("Player").GetComponent<SpriteRenderer>();
                playerimage.color = new Color(1f, 1f, 1f, 1f);
            }

            if (tea && Input.GetKeyDown(KeyCode.R))
            {
                print("찻잔 사용");
                teaCupCount = 0;

                if (teaCupCount <= 0)
                {
                    teaCupImage.color = transparentColor;
                    tea = false;
                }
            }
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
            if (vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            animator.SetBool("Walking", true);

            if (vector.x != 0)
            {
                transform.Translate(vector.x * speed, 0, 0);
            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * speed, 0);
            }

            yield return new WaitForSeconds(0.01f);

            // currentWalkCount = 0;
        }
        canMove = true;
        animator.SetBool("Walking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            PlayGame = 1;
            Destroy(collision.gameObject);
        }

        // 아이템 충돌 태그
        if (collision.gameObject.CompareTag("Time"))
        {
            Destroy(collision.gameObject);
            print("시계먹음");
            eatTime = true;
            timeCount += 1;
            timeCountNull += 1; // 누적 횟수
            timeImage.color = new Color(1f, 1f, 1f, 1f); // 시계 이미지를 원래대로 바꿔줌
        }

        if (collision.gameObject.CompareTag("Hat"))
        {
            Destroy(collision.gameObject);
            print("모자먹음");
            defense = true;
            hatCount += 1;
            hatCountNull += 1; // 누적 횟수
            hatImage.color = new Color(1f, 1f, 1f, 1f); // 모자 이미지를 원래대로 바꿔줌
        }

        if (collision.gameObject.CompareTag("TeaCup"))
        {
            Destroy(collision.gameObject);
            print("찻잔먹음");
            tea = true;
            teaCupCount += 1;
            teaCupCountNull += 1; // 누적 횟수
            teaCupImage.color = new Color(1f, 1f, 1f, 1f); // 찻잔 이미지를 원래대로 바꿔줌
        }

        if (tt == false)
        {
            // 적들과 충돌 처리
            if (collision.gameObject.CompareTag("Rabbit"))
            {
                if (jonyatimer > 0)
                {
                    Destroy(collision.gameObject);
                    jonyatimer -= Time.deltaTime;

                }
                else
                {
                    if (defense == true)
                    {
                        Destroy(collision.gameObject);

                        defense = false;
                        hatCount = 0;
                    }

                    else
                    {
                        Destroy(collision.gameObject);
                        TakeDamage(RabbitDmg);
                        ActivateDamageImage();
                    }
                    jonyatimer += Time.deltaTime*3;
                }
            }
            

            if (defense == false)
            {
                Color transparentColor = new Color(1f, 1f, 1f, 0.4f); // 모자 사용하면 ui투명
                hatImage.color = transparentColor;
            }
        }
        // 도착지점 충돌 처리
        if (collision.gameObject.CompareTag("finish"))
        {
            Finish();
        }
    }

    private void ActivateDamageImage()
    {
        Image damageImage = GameObject.Find("effect").GetComponent<Image>();

        if (damageImage != null)
        {
            damageImage.color = new Color(1f, 0f, 0f, 1f);; // 데미지를 입으면 붉은색 화면
            StartCoroutine(DelayedDisableDamageImage());
        }
    }

    private IEnumerator DelayedDisableDamageImage() // 코루틴
    {
        Image damageImage = GameObject.Find("effect").GetComponent<Image>();
        yield return new WaitForSeconds(0.5f);

        damageImage.color = new Color(0f, 0f, 0f, 0f);
    }

    private void TakeDamage(int damageAmount)
    {
        PlayerHp -= damageAmount;
        if (PlayerHp == 2)
        {
            GameObject heartObject = GameObject.Find("Heart");
            if (heartObject != null)
            {
                SpriteRenderer spriteRenderer = heartObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Destroy(spriteRenderer.gameObject);
                }
            }
        }
        if (PlayerHp == 1)
        {
            GameObject heartObject = GameObject.Find("Heart1");
            if (heartObject != null)
            {
                SpriteRenderer spriteRenderer = heartObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Destroy(spriteRenderer.gameObject);
                }
            }
        }
        if (PlayerHp <= 0)
        {
            GameObject heartObject = GameObject.Find("Heart2");
            if (heartObject != null)
            {
                SpriteRenderer spriteRenderer = heartObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Destroy(spriteRenderer.gameObject);
                }
            }
            term -= Time.deltaTime;
            if (term <= 0f) Die();
        }
    }

    private void Die()
    {   // game_data.csv 파일 경로
        int num = CheckData.instance.notlogin;
        if (num != 1)
        {
            string id = CheckData.instance.idInputField.text;
            string FilePath = Path.Combine(Application.dataPath, "UserData/");

            string userFilePath = Path.Combine(FilePath, id + ".csv");
            string gameData = string.Format("Kills: {0}, Card Eat: {1}, Hat Eat: {2}, Time Eat: {3}, TeaCup Eat: {4}", KillCountNull, CardCountNull, hatCountNull, timeCountNull, teaCupCountNull);
            File.AppendAllText(userFilePath, gameData + "\n");
            Debug.Log("저장");
        }
        else
        {
            Debug.Log("저장할 데이터 없음");
        }

        SceneManager.LoadScene("Die");
    }

    private void Finish()
    {
        SceneManager.LoadScene("Finish");
    }
}
