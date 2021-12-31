using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int HP = 10;
    public GameObject childe;
    PlayerHPVisualisation playerHPvisualise;
    public GameObject camera;
    Game game;
    public ParticleSystem particalSystemBlockCrash;
    private AudioSource brakeSound;
    private float dot;
    private Vector3 normalPlayerMoove = Vector3.forward;


    void Start()
    {
        playerHPvisualise = childe.GetComponent<PlayerHPVisualisation>();
        game = camera.GetComponent<Game>();
        brakeSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out BadSector badSector))
        {
            //dot = Vector3.Dot(collision.contacts[0].normal.normalized, normalPlayerMoove.normalized);
            //Debug.Log(dot);
            //if (dot != -1)
            //{
            //    return;
            //}


            HP--;
            playerHPvisualise.UpdateVisualisation();
            UI.score++;

            badSector.BadSectorHP--;
            badSector.UpdateBadSectorHP();

            if (HP == 0)
            {
                game.OnPlayerDie();
            }

            if (badSector.BadSectorHP == 0)
            {
                particalSystemBlockCrash.transform.position = collision.gameObject.transform.position;
                
                brakeSound.Play();
                Destroy(collision.gameObject);
                particalSystemBlockCrash.Play();
            }
        }

        if (collision.collider.TryGetComponent(out Food food))
        {
            HP += food.HP;
            playerHPvisualise.UpdateVisualisation();
            Destroy(food.gameObject);
        }

        if (collision.collider.TryGetComponent(out Finish fifnish))
        {
            game.OnPlayerWin();
        }
    }
}
