using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private float _invincibilityDuration = 2f;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
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
        else if (other.CompareTag("Medkit"))
        {
            //GainHealth(other.GetComponent<Medkit>().HealthRestored);
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
        //UpdateUI
    }

    private void GainHealth(int value)
    {
        _currentHealth += value;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        //UpdateUI
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
