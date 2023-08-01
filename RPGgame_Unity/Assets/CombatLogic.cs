using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CombatLogic : MonoBehaviour
{
    public GameObject CombatScreen;
    public GameObject TitleScreen;
    public PlayerStatblock PlayerStatblock;
    public NPCStatblock NPCStatblock;
    public Text Outcome;
    public string[] Options;

    public void StartGame()
    {
        TitleScreen.SetActive(false); 
        CombatScreen.SetActive(true);
        PlayerStatblock.Start();
        NPCStatblock.Start();
    }

    public void Play(string playerAction)
    {
        if (NPCStatblock.loss_streak != 2)
        {
            if (PlayerStatblock.PCAlive && NPCStatblock.NPCAlive)
            {
                string enemyAction = Options[UnityEngine.Random.Range(0, Options.Length)];
                switch (enemyAction)
                {
                    case "Melee":
                        switch (playerAction)
                        {
                            case "Melee":
                                Outcome.text = "The combatants clash, wounding each other.";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-10f);
                                NPCStatblock.SetHealth(-10f);
                                break;
                            case "Shield":
                                Outcome.text = "The adventurer parries and lands a counterattack!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                NPCStatblock.SetHealth(-20f);
                                NPCStatblock.loss_streak++;
                                break;
                            case "Magic":
                                Outcome.text = "The enemy strikes suddenly, breaking the adventurer's spell!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-20f);
                                break;
                        }
                        break;
                    case "Shield":
                        switch (playerAction)
                        {
                            case "Melee":
                                Outcome.text = "The adventurer's strike is parried and a counterattack lands on them!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-20f);
                                break;
                            case "Shield":
                                Outcome.text = "Both combatants land glancing blows on each other.";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-10f);
                                NPCStatblock.SetHealth(-10f);
                                break;
                            case "Magic":
                                Outcome.text = "The adventurer's spell cuts through the enemy's defenses!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                NPCStatblock.SetHealth(-20f);
                                NPCStatblock.loss_streak++;
                                break;
                        }
                        break;
                    case "Magic":
                        switch (playerAction)
                        {
                            case "Melee":
                                Outcome.text = "The adventurer strikes first, breaking the enemy's spell!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                NPCStatblock.SetHealth(-20f);
                                NPCStatblock.loss_streak++;
                                break;
                            case "Shield":
                                Outcome.text = "The adventurer's defenses are overwhelmed by the enemy's spell!";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-20f);
                                break;
                            case "Magic":
                                Outcome.text = "The spells collide and explode between the combatants.";
                                PlayerStatblock.ChangeSprite(playerAction);
                                NPCStatblock.ChangeSprite(enemyAction);
                                PlayerStatblock.SetHealth(-10f);
                                NPCStatblock.SetHealth(-10f);
                                break;
                        }
                        break;
                }
            }
        }
        else
        {
            if (PlayerStatblock.PCAlive && NPCStatblock.NPCAlive)
            {
                switch (playerAction)
                {
                    case "Melee":
                        Outcome.text = "The foe predicts your action.";
                        PlayerStatblock.ChangeSprite(playerAction);
                        NPCStatblock.ChangeSprite("Shield");
                        PlayerStatblock.SetHealth(-10f);
                        NPCStatblock.loss_streak = 0;
                        break;
                    case "Shield":
                        Outcome.text = "The foe predicts your action.";
                        PlayerStatblock.ChangeSprite(playerAction);
                        NPCStatblock.ChangeSprite("Magic");
                        PlayerStatblock.SetHealth(-10f);
                        NPCStatblock.loss_streak = 0;
                        break;
                    case "Magic":
                        Outcome.text = "The foe predicts your action.";
                        PlayerStatblock.ChangeSprite(playerAction);
                        NPCStatblock.ChangeSprite("Melee");
                        PlayerStatblock.SetHealth(-10f);
                        NPCStatblock.loss_streak = 0;
                        break;
                }
            }
        }
    }
}