
using UnityEngine;

public class MenacingEye : MonoBehaviour
{
    [SerializeField] private GameObject _thePlayer;
    void Update()
    {
        this.transform.LookAt(_thePlayer.transform.position);
    }
}
