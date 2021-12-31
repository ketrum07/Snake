using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform Head;
    public float BodyDiameter;
    public GameObject TailPrefab;


    private List<Transform> tail = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        positions.Add(Head.position);
        AddBall();
        AddBall();
        AddBall();
        AddBall();
    }

    void Update()
    {
        float _distance = (Head.position - positions[0]).magnitude;

        if (_distance > BodyDiameter)
        {
            Vector3 direction = (Head.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * BodyDiameter);
            positions.RemoveAt(positions.Count - 1);
            _distance -= BodyDiameter;
        }

        for (int i = 0; i < tail.Count; i++)
        {
            tail[i].position = Vector3.Lerp(positions[i + 1], positions[i], _distance / BodyDiameter);
        }
    }

    public void AddBall()
    {
        GameObject ball = Instantiate(TailPrefab, positions[positions.Count - 1], Quaternion.identity, transform);
        tail.Add(ball.transform);
        positions.Add(ball.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.TryGetComponent(out BadSector badSector))
        {
            if (positions.Count == 1) return;
            
              RemoveBall();
        }

        if (collision.collider.TryGetComponent(out Food eat))
        {
            for (int i = 0; i < eat.HP; i++)
            {
                AddBall();
            }
        }
    }

    public void RemoveBall()
    {
        Destroy(tail[0].gameObject);
        tail.RemoveAt(0);
        positions.RemoveAt(1);
    }
}


