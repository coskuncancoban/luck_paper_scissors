using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticaInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticaInput) * speed * Time.deltaTime);
    }
}
