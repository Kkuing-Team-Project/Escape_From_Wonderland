using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance; // �ν��Ͻ�
    public GameObject[] PalyerUIHp;
    // public Image damageImage; // �� ȿ��
    public Color flashColour = new Color(1f, 0f, 0f, 0.2f); // ��� ������ ����

    public float speed;
    public int walkcount;
    public int PlayerHp = 3;
    public int RabbitHp;
    public int RabbitDmg = 1;

    private Vector3 vector;
    private Animator animator;
    private int currentWalkCount;
    private float term = 0f;
    private bool canMove = true;

    float timeImpactTimer = 0;

    bool eatTime = false;
    bool defense = false;
    bool tea = false;

    private Collider2D coll;
    private SpriteRenderer spriter;
    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();

        Image damageImage = GameObject.Find("Damge").GetComponent<Image>();
        damageImage.color = new Color(0f, 0f, 0f, 0f);
    }

    private void Update()
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
        }

        if (timeImpactTimer > 0)
        {
            timeImpactTimer -= Time.deltaTime;
            coll.enabled = false;

        }
        else
        {
            coll.enabled = true;
            spriter.color = new Color(1, 1, 1, 1);
        }
        if (eatTime && Input.GetKeyDown(KeyCode.E))
        {
            print("�ð� ���");
            timeImpactTimer = 2;
            eatTime = false;
            spriter.color = new Color(1, 1, 1, 0.5f);
        }
        if (tea && Input.GetKeyDown(KeyCode.R))
        {
            print("���� ���");
            tea = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("ī����");
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
            if(vector.x != 0)
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

            currentWalkCount = 0;
        }
        canMove = true;
        animator.SetBool("Walking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ������ �浹 tage
        if (collision.gameObject.CompareTag("Time"))
        {
            Destroy(collision.gameObject);
            print("�ð����");
            eatTime = true;
        }
        if (collision.gameObject.CompareTag("Hat"))
        {
            Destroy(collision.gameObject);
            print("���ڸ���");
            defense = true;
        }
        if (collision.gameObject.CompareTag("TeaCup"))
        {
            Destroy(collision.gameObject);
            print("���ܸ���");
            tea = true;
        }

        // ����� �浹 ó��
        
        if (collision.gameObject.CompareTag("Rabbit"))
        {
            if (defense == true)
            {
                
                Destroy(collision.gameObject);
                defense = false;
            }

            else
            {
                Destroy(collision.gameObject);
                TakeDamage(RabbitDmg);
                ActivateDamageImage();
            }
        }

    }
    private void ActivateDamageImage()
    {
        Image damageImage = GameObject.Find("Damge").GetComponent<Image>();

        if (damageImage != null)
        {
            damageImage.color = flashColour; // �������� ������ ������ ȭ��
            StartCoroutine(DelayedDisableDamageImage());
        }
    }

    private IEnumerator DelayedDisableDamageImage() // �ڷ�ƾ
    {
        Image damageImage = GameObject.Find("Damge").GetComponent<Image>();
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
        if(PlayerHp == 1)
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
    {
        SceneManager.LoadScene("Die");
    }
}
