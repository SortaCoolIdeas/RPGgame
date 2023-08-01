using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCStatblock : MonoBehaviour
{
    public float Health, MaxHealth;
    public int score = 0;
    public Text scoreText;
    public GameObject VictoryScreen;
    public bool NPCAlive = true;
    public NPCStatblock NPCStats;
    public int loss_streak = 0;

    public SpriteRenderer NPCspriteRenderer;
    public Sprite idle, melee, magic, shield;

    [SerializeField]
    private HealthBarUI healthBar;

    public void ChangeSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Melee":
                NPCspriteRenderer.sprite = melee;
                break;
            case "Magic":
                NPCspriteRenderer.sprite = magic;
                break;
            case "Shield":
                NPCspriteRenderer.sprite = shield;
                break;
            case "Idle":
                NPCspriteRenderer.sprite = idle;
                break;
        }
    }

    public void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        NPCspriteRenderer = GetComponent<SpriteRenderer>();
        idle = Resources.Load<Sprite>("Pixil-frame-idle");
        melee = Resources.Load<Sprite>("Pixil-frame-melee");
        magic = Resources.Load<Sprite>("Pixil-frame-magic");
        shield = Resources.Load<Sprite>("Pixil-frame-shield");
        NPCspriteRenderer.sprite = idle;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            SetHealth(-20f);
        }
        if (Input.GetKeyDown("y"))
        {
            SetHealth(20f);
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);

        if (Health == 0)
        {
            NPCAlive = false;
            Victory();
        }
    }

    public void Continue()
    {
        VictoryScreen.SetActive(false);
        NPCAlive = true;
        healthBar.SetHealth(100f);
        NPCspriteRenderer.sprite = idle;
    }
    public void Victory()
    {
        score++;
        scoreText.text = score.ToString();
        VictoryScreen.SetActive(true);
    }
}