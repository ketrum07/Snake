using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public Vector3 delta;

    void Update()
    {
        transform.position = player.transform.position + delta;
    }
}
