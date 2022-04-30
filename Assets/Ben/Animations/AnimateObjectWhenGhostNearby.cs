using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObjectWhenGhostNearby : MonoBehaviour
{
    
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_animator != null)
        {
            Debug.Log("detected");
            if (other.tag == "GhostHardDetect")
                {
                Debug.Log("detected Hard");
                _animator.speed = 2.0f;
                 _animator.SetBool("isPlaying", true);
                 }else if (other.tag == "GhostSoftDetect") 
                 {
                  _animator.speed = 1.0f;
                  _animator.SetBool("isPlaying", true);
                Debug.Log("detected soft");
                 }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_animator != null)
        {
            if (other.tag == "GhostHardDetect")
            {
                _animator.speed = 1.0f;
            }
            else if (other.tag == "GhostSoftDetect")
            {
                _animator.SetBool("isPlaying", false);
            }
        }
    }
}
