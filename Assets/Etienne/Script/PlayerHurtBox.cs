using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _invincibilityDuration = 2f;
    private int _currentHealth = 3;

    private void Start()
    {
        if(UIManager.Instance != null)
        {
            _currentHealth = UIManager.Instance.PlayerMaxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GhostHitBox"))
        {
            LoseHealth(other.GetComponent<GhostHit>().Damage);
        }
        else if (other.CompareTag("SentryHitBox"))
        {
            LoseHealth(other.GetComponent<SentryHit>().Damage);
        }
        else if (other.CompareTag("Health") && UIManager.Instance.PlayerCurrentHealth != UIManager.Instance.PlayerMaxHealth)
        {
            GainHealth(other.GetComponent<HealthPickup>().HealthRestored);
            Destroy(other.gameObject);
        }
    }

    private void LoseHealth(int value)
    {
        _currentHealth -= value;
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            _animator.Play("Defeated");
        }
        else
        {
            StartCoroutine(InvincibilityRoutine());
        }
        if (UIManager.Instance != null)
        {
            UIManager.Instance.TakeDamage(value);
        }
    }

    private void GainHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth > UIManager.Instance.PlayerMaxHealth)
        {
            _currentHealth = UIManager.Instance.PlayerMaxHealth;
        }
        if (UIManager.Instance != null)
        {
            UIManager.Instance.GainHealth(value);
        }
    }

    private IEnumerator InvincibilityRoutine()
    {
        _animator.Play("Invincible");
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(_invincibilityDuration);

        _animator.Play("Normal");
        GetComponent<Collider>().enabled = true;
    }
}
