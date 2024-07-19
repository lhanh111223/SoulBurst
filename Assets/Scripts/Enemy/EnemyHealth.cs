using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private PlayerCoinBar playerCoinBar;
    private Canvas enemyCanvas;
    public GameObject floatingHealthPrefab;
    void Start()
    {
        currentHealth = maxHealth;
        playerCoinBar = FindObjectOfType<PlayerCoinBar>();
        enemyCanvas = GetComponentInChildren<Canvas>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (floatingHealthPrefab != null)
        {
            ShowFloatingText(amount);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        int coinAmount = Random.Range(1, 11);

        if (playerCoinBar != null)
        {
            playerCoinBar.IncreaseCoin(coinAmount);
        }
        Destroy(gameObject);
    }
    private void ShowFloatingText(int damage)
    {
        GameObject text = Instantiate(floatingHealthPrefab, enemyCanvas.transform.position, Quaternion.identity, enemyCanvas.transform);
        if (transform.localScale.x < 0 && enemyCanvas.transform.localScale.x > 0)
        {

            enemyCanvas.transform.localScale = new Vector3(enemyCanvas.transform.localScale.x * -1,
                enemyCanvas.transform.localScale.y,
                enemyCanvas.transform.localScale.z);
            Debug.Log(enemyCanvas.transform.localScale.x);
        }
        if (transform.localScale.x > 0 && enemyCanvas.transform.localScale.x < 0)
        {

            enemyCanvas.transform.localScale = new Vector3(enemyCanvas.transform.localScale.x * -1,
                enemyCanvas.transform.localScale.y,
                enemyCanvas.transform.localScale.z);
            Debug.Log(enemyCanvas.transform.localScale.x);
        }
        text.GetComponent<TextMesh>().text = damage.ToString();
    }
}
