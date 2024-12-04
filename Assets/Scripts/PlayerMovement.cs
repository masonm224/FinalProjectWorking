using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float horizontalInput;
    public float boundary = 11;
    private Vector3 originalScale;
    SpawnManager _SpawnManager;


    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        SpawnManager _SpawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_SpawnManager.isGameActive)
        {
        ResetSize();
        }
        //Player Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //Left Boundary
        if (transform.position.x < -boundary){
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }
        //Right Boundary
        if (transform.position.x > boundary){
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }

     }

     public void ResetSize()
     {
        transform.localScale = new Vector3(2, .08f, .2f);
     }
}
