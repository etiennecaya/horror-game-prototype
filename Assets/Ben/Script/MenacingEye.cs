
using UnityEngine;

public class MenacingEye : MonoBehaviour
{
    private GameObject _thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(_thePlayer.transform.position);
    }
}
