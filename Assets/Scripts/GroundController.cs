using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    Vector3 startPos;
    float sizeX;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        sizeX = GetComponent<BoxCollider2D>().size.x / 2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (this.transform.position.x < startPos.x - sizeX)
            this.transform.position = startPos;
    }
}
