using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Jobs;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    bool pressedClick;

    int points;
    [SerializeField] TextMeshProUGUI pointsText;
    bool canclick;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameOverBtn;
    [SerializeField] GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
        canclick = true;
        points = 0;
        pressedClick = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartGameController.instance.gameStarted)
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        else
            rb2d.constraints = RigidbodyConstraints2D.None;

        if (Input.GetMouseButtonDown(0) && canclick)
        {
            pressedClick = true;
        }

        this.transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (pressedClick)
        {
            rb2d.velocity = Vector2.up * speed * Time.deltaTime;
            pressedClick = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            canclick = false;
            StartGameController.instance.gameOver = true;
            gameOver.SetActive(true);
            gameOverBtn.SetActive(true);
            fade.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Points"))
        {
            points++;
            pointsText.text = points.ToString();
        }
    }
}
