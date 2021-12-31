using UnityEngine;
using TMPro;

public class SectorHPvisualisation : MonoBehaviour
{
    public TextMeshPro text;
    public int HP;

    private void Start ()
    {
        text.text = GetComponentInParent<BadSector>().BadSectorHP.ToString();
    }

    public void UpdateVisualisation()
    {
        text.text = HP.ToString();
    }
}
