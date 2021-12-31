using TMPro;
using UnityEngine;

public class FoodHPvisualisation : MonoBehaviour
{
    public TextMeshPro text;
    public int HP;

    private void Start()
    {
        text.text = GetComponentInParent<Food>().HP.ToString();
    }
}
