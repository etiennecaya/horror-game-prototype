using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObjectWhenGhostNearby : MonoBehaviour
{
    
    private Animator _animator;
    private int _nbHardDetect;
    private int _nbSoftDetect;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator != null)
        {
            
            if (_nbSoftDetect >= 1)
            {
                _animator.SetBool("isPlaying", true);
                if (_nbHardDetect < 1)
                {
                    _animator.speed = 1.0f;
                } else
                {
                    _animator.speed = 2.0f;
                }
            } else
            {
                _animator.SetBool("isPlaying", false);
            }
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "GhostHardDetect")
            {
            _nbHardDetect++;
            }
            if (other.tag == "GhostSoftDetect") 
            {
            _nbSoftDetect++;
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
            if (other.tag == "GhostHardDetect")
            {
            _nbHardDetect--;
            }
            else if (other.tag == "GhostSoftDetect")
            {
            _nbSoftDetect--;
            }
        
    }
}
