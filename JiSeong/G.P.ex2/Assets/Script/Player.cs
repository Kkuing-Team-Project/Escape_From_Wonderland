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
    public int card;
    private float rechargeTimer;
    public int maxCard = 3;
    private int maxHp = 3;
    public int RabbitHp;
    public int RabbitDmg = 1;
    public SpriteRenderer[] heartSprites;

    private bool isJumping = false;
    private float jumpForce = 5f;
    public Card attack;

    private Vector3 vector;
    private Animator animator;
    // private int currentWalkCount;
    private bool canMove = true;

    float timeImpactTimer = 0f;
    public float cardTime = 5f;
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
    public float distance = 0;
    public Button jumpBtn;

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

        // TeaCup, Hat, Time �̹����� 70% �������ϰ� ����
        Color transparentColor = new Color(1f, 1f, 1f, 0.4f);

        teaCupImage.color = transparentColor;
        hatImage.color = transparentColor;
        timeImage.color = transparentColor;
        UpdateHeartSprites();
        card = maxCard;  // 시작할 때 최대 아이템 개수로 초기화
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
            // 아이템 충전 타이머 갱신
            rechargeTimer += Time.deltaTime;

            // 5초마다 아이템 충전
            if (rechargeTimer >= cardTime && card < maxCard)
            {
                rechargeTimer = 0f;
                RechargeItem();
            }

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
                if (card > 0)
                {
                    animator.SetTrigger("run attack");
                    Instantiate(attack, transform.position, Quaternion.identity);
                    CardCountNull += 1;
                    rechargeTimer = 0f;
                    card--;  // 아이템 개수 감소
                }
                else
                {
                    Debug.Log("아이템이 없습니다.");
                }
            }

                Color transparentColor = new Color(1f, 1f, 1f, 0.4f);

            if (eatTime && Input.GetKeyDown(KeyCode.E))
            {
                print("�ð� ���");
                timeImpactTimer = 2;
                timeCount = 0; ;
                eatTime = false;
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
                print("���� ���");
                Heal(1);
                teaCupCount = 0;
                
                if (teaCupCount <= 0)
                {
                    teaCupImage.color = transparentColor;
                    tea = false;
                }
            }
            jonyatimer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                print("jump!!");
                isJumping = true;
            }

        }
    }

    private void RechargeItem()
    {
        card++;  // 아이템 개수 증가
        print("충전");
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
        if (collision.gameObject.CompareTag("start"))
        {
            PlayGame = 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Map")){
            // Player 오브젝트의 현재 위치를 가져옴
            Vector3 currentPosition = transform.position;

            // Player 오브젝트의 위치를 y축으로 -1칸 내림
            currentPosition.y -= 0.5f;

            // 변경된 위치를 적용하여 Player 오브젝트를 이동시킴
            transform.position = currentPosition;
        }

        if (collision.gameObject.CompareTag("Map2")){
            // Player 오브젝트의 현재 위치를 가져옴
            Vector3 currentPosition = transform.position;

            // Player 오브젝트의 위치를 y축으로 +1칸 내림
            currentPosition.y += 0.5f;

            // 변경된 위치를 적용하여 Player 오브젝트를 이동시킴
            transform.position = currentPosition;

        }

        // ������ �浹 �±�
        if (collision.gameObject.CompareTag("Time"))
        {
            Destroy(collision.gameObject);
            print("�ð����");
            eatTime = true;
            timeCount += 1;
            timeCountNull += 1; // ���� Ƚ��
            timeImage.color = new Color(1f, 1f, 1f, 1f); // �ð� �̹����� ������� �ٲ���
        }

        if (collision.gameObject.CompareTag("Hat"))
        {
            Destroy(collision.gameObject);
            print("���ڸ���");
            defense = true;
            hatCount += 1;
            hatCountNull += 1; // ���� Ƚ��
            hatImage.color = new Color(1f, 1f, 1f, 1f); // ���� �̹����� ������� �ٲ���
        }

        if (collision.gameObject.CompareTag("TeaCup"))
        {
            Destroy(collision.gameObject);
            print("���ܸ���");
            tea = true;
            teaCupCount += 1;
            teaCupCountNull += 1; // ���� Ƚ��
            teaCupImage.color = new Color(1f, 1f, 1f, 1f); // ���� �̹����� ������� �ٲ���
        }




        if (tt == false)
        {
            // ����� �浹 ó��
            if (collision.gameObject.CompareTag("Rabbit"))
            {
                if (jonyatimer > 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    if (defense == true)
                    {
                        Destroy(collision.gameObject);

                        defense = false;
                        hatCount = 0;
                        print("���ڻ��");
                    }

                    else
                    {
                        Destroy(collision.gameObject);
                        TakeDamage(RabbitDmg);
                        ActivateDamageImage();
                        print("����");
                    }
                    jonyatimer = 0.1f;
                }
            }
            

            if (defense == false)
            {
                Color transparentColor = new Color(1f, 1f, 1f, 0.4f); // ���� ����ϸ� ui����
                hatImage.color = transparentColor;
            }
        }
        // �������� �浹 ó��
        if (collision.gameObject.CompareTag("finish"))
        {
            Finish();
        }
        if (jonyatimer > 0)
        {
            SpriteRenderer playerimage = GameObject.Find("Player").GetComponent<SpriteRenderer>();
            playerimage.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            SpriteRenderer playerimage = GameObject.Find("Player").GetComponent<SpriteRenderer>();
            playerimage.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void ActivateDamageImage()
    {
        Image damageImage = GameObject.Find("effect").GetComponent<Image>();

        if (damageImage != null)
        {
            damageImage.color = new Color(1f, 0f, 0f, 1f);; // �������� ������ ������ ȭ��
            StartCoroutine(DelayedDisableDamageImage());
        }
    }

    private IEnumerator DelayedDisableDamageImage() // �ڷ�ƾ
    {
        Image damageImage = GameObject.Find("effect").GetComponent<Image>();
        yield return new WaitForSeconds(0.5f);

        damageImage.color = new Color(0f, 0f, 0f, 0f);
    }

    private void TakeDamage(int damageAmount)
    {
        PlayerHp -= damageAmount;
        if (PlayerHp <= 0)
        {
            Die();
        }
        UpdateHeartSprites();
    }
    private void Heal(int healAmount)
    {
        PlayerHp += healAmount;

        // 체력이 최대치를 넘지 않도록 제한
        PlayerHp = Mathf.Min(PlayerHp, maxHp); 

        UpdateHeartSprites(); // 체력 UI 이미지 업데이트
    }
    private void UpdateHeartSprites()
    {
        for (int i = 0; i < PlayerUIHp.Length; i++)
        {
            if (i < PlayerHp)
            {
                // 현재 체력 이상의 하트는 활성화
                PlayerUIHp[i].SetActive(true);
            }
            else
            {
                // 현재 체력 이하의 하트는 비활성화
                PlayerUIHp[i].SetActive(false);
            }
        }
    }


    private void Die()
    {
        // Calculate the distance
        distance = transform.position.x; // Get the x position of the player

        // game_data.csv ���� ���
        int num = CheckData.instance.notlogin;
        if (num != 1)
        {
            string id = CheckData.instance.idInputField.text;
            string FilePath = Path.Combine(Application.dataPath, "UserData/");

            string userFilePath = Path.Combine(FilePath, id + ".csv");
            //string gameData = string.Format("Kills: {0}, Card Eat: {1}, Hat Eat: {2}, Time Eat: {3}, TeaCup Eat: {4}, Distance: {5}", KillCountNull, CardCountNull, hatCountNull, timeCountNull, teaCupCountNull, distance);
            string gameData = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", KillCountNull, CardCountNull, hatCountNull, timeCountNull, teaCupCountNull, distance);
            File.AppendAllText(userFilePath, gameData + "\n");
            Debug.Log("����");
        }
        else
        {
            Debug.Log("������ ������ ����");
        }

        SceneManager.LoadScene("Die");
    }


    private void Finish()
    {
        SceneManager.LoadScene("Finish");
    }
}
