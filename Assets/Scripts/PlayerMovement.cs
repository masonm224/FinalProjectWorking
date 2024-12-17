using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float maxScaleX = 5f;
    public float scaleFactor = .25f;
    public float xScale = 2;
    public float initialScaleX;
    public float horizontalInput;
    public float boundary = 11;
    private Vector3 originalScale;
    public SpawnManager XSpawnManager;


    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        originalScale = transform.localScale;
        initialScaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (XSpawnManager.isGameActive == false)
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
        transform.localScale = new Vector3(xScale, .08f, .2f);
     }

     public void IncreaseWidth()
     {
         if (XSpawnManager.skillPoints >= 1)
         {
        transform.localScale += new Vector3(scaleFactor, 0f, 0f);
        //Wanted to put skillPoints -= 1 but it didnt like
        XSpawnManager.skillPoints = XSpawnManager.skillPoints - 1;
         }
     }
     
     public void SpeedButton()
     {
        if (XSpawnManager.skillPoints >= 1)
        {
            speed += .5f;
            XSpawnManager.skillPoints = XSpawnManager.skillPoints - 1;
        }
     }


}
