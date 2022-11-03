using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour

{
    [Header("Defualt Speed")]
    //speed for movement
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //i dont feellike typing
       transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
