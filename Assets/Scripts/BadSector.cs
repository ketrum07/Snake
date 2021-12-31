using System;
using UnityEngine;

public class BadSector : MonoBehaviour
{
    [Min(0)]
    public int BadSectorHP;
    private int MaxBadSectorHP = 20;
    private SectorHPvisualisation child;
    public  Material material;
    Gradient gradient = new Gradient();


    private void Start()
    {
        if (BadSectorHP > MaxBadSectorHP)
        {
            BadSectorHP = MaxBadSectorHP;
        }
        child = GetComponentInChildren<SectorHPvisualisation>();
        child.HP = BadSectorHP;
        MakeGradient();
        SetColour(gradient);
    }


    public void UpdateBadSectorHP()
    {
        child.HP = BadSectorHP;
        child.UpdateVisualisation();
        SetColour(gradient);
    }

    private void SetColour(Gradient g)
    {
        gameObject.GetComponent<Renderer>().material.color = g.Evaluate((float)child.HP/MaxBadSectorHP);
    }

    void MakeGradient()
    {
        GradientColorKey[] gck = new GradientColorKey[2];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gck[0].color = Color.red;
        gck[0].time = 1.0F;

        gck[1].color = Color.green;
        gck[1].time = -1.0F;

        gak[0].alpha = 0.0F;
        gak[0].time = 1.0F;

        gak[1].alpha = 0.0F;
        gak[1].time = -1.0F;

        gradient.SetKeys(gck, gak);
    }

}
