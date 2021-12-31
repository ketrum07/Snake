using System.Threading.Tasks;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float ForvardSpeed = 5f;
    private float strafeSpeed = 5f;
    private Rigidbody PlayerRB;
    float moovment;
    public float boulForce = 5f;
    public GameObject Head;
    private Vector3 normalPlayerMoove = Vector3.forward;
    private float dot;
    

        void  Start()
    {
        PlayerRB = Head.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moovment = Input.GetAxis("Horizontal");

        if (moovment > 0)
        {
            PlayerRB.transform.position += new Vector3(1, 0, 0) * strafeSpeed * Time.deltaTime;
        }
        else if (moovment < 0)
        {
            PlayerRB.transform.position += new Vector3(-1, 0, 0) * strafeSpeed * Time.deltaTime;
        }
    }

    private void MooveForward()
    {
        if (PlayerRB == null) return;
        PlayerRB.AddForce(new Vector3(0, 0, ForvardSpeed * 2), ForceMode.Impulse);
    }
    
    public void StartMooveForward()
    {
        if (PlayerRB == null) return;
        PlayerRB.AddForce(new Vector3(0, 0, ForvardSpeed), ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out BadSector badSector))
        {
            dot = Vector3.Dot(collision.contacts[0].normal.normalized, normalPlayerMoove.normalized);
            Debug.Log(dot);
            if (dot != -1)
            {
                PlayerRB.velocity = Vector3.zero;
            }
            Boul();
        }

        return;
    }

    public async void Boul()
    {
        PlayerRB.AddForce(new Vector3(0, 0, -boulForce), ForceMode.VelocityChange);
        await Task.Delay (150);
        MooveForward();
    }
}
