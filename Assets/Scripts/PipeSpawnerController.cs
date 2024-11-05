using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerController : MonoBehaviour
{
    [SerializeField] float initialYLimit;
    [SerializeField] float finalYLimit;
    [SerializeField] float fixedXPosition;

    [SerializeField] GameObject pipePrefab;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGameController.instance.gameStarted && !StartGameController.instance.gameOver)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                var randomY = Random.Range(initialYLimit, finalYLimit);

                var newPipes = Instantiate(pipePrefab);
                newPipes.transform.position = new Vector3(fixedXPosition, randomY, this.transform.position.z);

                timer = 0;
            }
        }
    }
}
