using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Makes UI elements appear/disappear accordingly
/// Contains images and sprites of hearts and powerups
/// Also calculates health of the player
/// NOTE: hearts exceding the starting health (3) 
/// will not be leaving behind an empty heart container when lost
/// </summary>
public class PowerUpUI : MonoBehaviour
{
    public Image imageSprint, imageDoubleJump;
    public Player player;
    public List<Image> hearts;
    public Image imageHeart;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private const int maxHearts = 5;
    private bool powerUpFlagHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        imageSprint.enabled = false;
        imageDoubleJump.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the list contains the powerup to display them.
        if (player.activePowerUps.Contains(Player.ePowerUp.DoubleJump))
        {
            imageDoubleJump.enabled = true;
        }
        if (player.activePowerUps.Contains(Player.ePowerUp.Sprint))
        {
            imageSprint.enabled = true;
        }
        if (player.activePowerUps.Contains(Player.ePowerUp.Health))
        {
            powerUpFlagHealth = true;
        }
        //calc health and display hearts
        if (powerUpFlagHealth == true)
        {
            //adds health when picking up life-powerup
            if (player.health < maxHearts)
            {
                player.health++;    //add life
                player.activePowerUps.Remove(Player.ePowerUp.Health);
                powerUpFlagHealth = false;
            }
        }
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < player.health)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true;
            }
            //changes sprites of full hearts to empty hearts
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (player.health <= 3)
        {
            hearts[3].enabled = false;
            hearts[4].enabled = false;
        }
    }

}
