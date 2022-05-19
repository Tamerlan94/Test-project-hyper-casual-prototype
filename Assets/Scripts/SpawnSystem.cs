using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject cupPrefab;
    [SerializeField] private GameObject handPrefab;

    [SerializeField] private Vector3 _min;
    [SerializeField] private Vector3 _max;
    [SerializeField] private float _maxDistanceDelta;
    [SerializeField] private float _step;

    [SerializeField] private GameObject hand;
    [SerializeField] private Vector3 handPosition;
    [SerializeField] private bool isLeft;
    [SerializeField] private Transform spawnedCups;

    private void Start()
    {
        hand = Instantiate(handPrefab);
        hand.transform.position = handPosition;
    }
    private void Update()
    {
        MoveHand();

        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
    private void MoveHand()
    {
        if (!isLeft)
        {
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, _max, _maxDistanceDelta);
            if (hand.transform.position.x >= _max.x)
            {
                isLeft = true;
            }
        }
        else
        {
            hand.transform.position = Vector3.MoveTowards(hand.transform.position, _min, _maxDistanceDelta);
            if (hand.transform.position.x <= _min.x)
            {
                isLeft = false;
            }
        }
    }
    private void Spawn()
    {
        GameObject obj = Instantiate(cupPrefab, spawnedCups);
        obj.transform.position = hand.GetComponent<Hand>().spawnPosition.position;
    }
}
