using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float smoothness;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Player.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position - offset, smoothness);
    }
}
