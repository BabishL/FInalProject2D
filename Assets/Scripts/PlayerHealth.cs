using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    public SpriteRenderer playerSR;
    public PlayerMovement playerMovement;

    public GameObject lPanel;
    public GameObject wPanel;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
     public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //playerSR.enabled = false; 
            //playerMovement.enabled = false;
            lPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            wPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
