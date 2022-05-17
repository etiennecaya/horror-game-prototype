using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _invincibilityDuration = 2f;


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
        if (UIManager.Instance != null)
        {
            UIManager.Instance.TakeDamage(value);
            if(UIManager.Instance.PlayerCurrentHealth > 0)
            {
                StartCoroutine(InvincibilityRoutine());
            }
        }


    }

    private void GainHealth(int value)
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.GainHealth(value);
        }
    }

    private IEnumerator InvincibilityRoutine()
    {
        _animator.Play("Invincible");
        transform.localScale = Vector3.zero;

        yield return new WaitForSeconds(_invincibilityDuration);

        _animator.Play("Normal");
        transform.localScale = Vector3.one;
    }
}
