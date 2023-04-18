using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemColector : MonoBehaviour
{
    bool dead = false;
    int score = 0;
    public Text scoreText;

    public GameObject spherePrefab;
    public GameObject playerPrefab;

    public Vector3 AreaCenter;
    public Vector3 AreaSize;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Material playerMaterial = playerPrefab.GetComponent<Renderer>().material;

            if (collision.gameObject.GetComponent<Renderer>().material.color == playerMaterial.color)
            {
                score++;
                Destroy(collision.gameObject);
                scoreText.text = "Score: " + score;
                newItem();
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<PLayerControler>().enabled = false;
                Die();
            }


        }
    }

    void Update()
    {
        if (score == 10)
        {
            SceneManager.LoadScene(2);
        }
    }

    void newItem()
    {
        Material playerMaterial = playerPrefab.GetComponent<Renderer>().material;

        Vector3 randomSpawnPosition = AreaCenter + new Vector3(Random.Range(-AreaSize.x / 2, AreaSize.x / 2),
                                                                       AreaSize.y,
                                                                       Random.Range(-AreaSize.z / 2, AreaSize.z / 2));

        GameObject newSphere = Instantiate(spherePrefab, randomSpawnPosition, Quaternion.identity);

        Material sphereMaterial = newSphere.GetComponent<Renderer>().material;

        sphereMaterial.color = playerMaterial.color;
    }

    void Die()
    {
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(3);
    }
}
