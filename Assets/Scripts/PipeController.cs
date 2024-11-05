using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        Invoke("DestroyAfterSeconds", 9f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * speed * Time.deltaTime; 
    }
    private void DestroyAfterSeconds()
    {
        Destroy(gameObject);
    }
}
