using UnityEngine;

public class Finish : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource finish = GetComponent<AudioSource>();
        finish.Play();
    }
}
