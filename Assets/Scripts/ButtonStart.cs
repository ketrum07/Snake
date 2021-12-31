using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject player;
    private Controls controls;

    private void Start()
    {
        controls = player.GetComponent<Controls>();
    }

    public void StartNewGame()
    {
        panelStart.gameObject.SetActive(false);
        controls.StartMooveForward();
    }

}
