using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatblock : MonoBehaviour
{
    public float Health, MaxHealth;
    public GameObject GameOverScene;
    public bool PCAlive = true;
    public PlayerStatblock PCStatblock;
    public NPCStatblock NPCstats;

    public SpriteRenderer PCspriteRenderer;
    public Sprite idle, melee, magic, shield;

    [SerializeField]
    private HealthBarUI healthBar;

    public void ChangeSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Melee":
                PCspriteRenderer.sprite = melee;
                break;
            case "Magic":
                PCspriteRenderer.sprite = magic;
                break;
            case "Shield":
                PCspriteRenderer.sprite = shield;
                break;
            case "Idle":
                PCspriteRenderer.sprite = idle;
                break;
        }
    }

    public void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        PCspriteRenderer = GetComponent<SpriteRenderer>();
        idle = Resources.Load<Sprite>("Pixil-frame-idle");
        melee = Resources.Load<Sprite>("Pixil-frame-melee");
        magic = Resources.Load<Sprite>("Pixil-frame-magic");
        shield = Resources.Load<Sprite>("Pixil-frame-shield");
        PCspriteRenderer.sprite = idle;
    }

    void Update()
    {
        if (Input.GetKeyDown("d")) 
        {
            SetHealth(-20f);
        }
        if (Input.GetKeyDown("h"))
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
            PCAlive = false;
            GameOver();
        }
    }

    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AdvanceStage()
    {
        healthBar.SetHealth(Health);
        PCspriteRenderer.sprite = idle;
    }
    public void GameOver()
    {
        GameOverScene.SetActive(true);
    }

}