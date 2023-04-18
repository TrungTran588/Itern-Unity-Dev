using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Tạo danh sách các mã màu theo hệ thập lục phân cho người chơi
        string[] ColorHex = new string[] { "#2F396C", "#FFDB55", "#CA1212" };

        int randomColor = Random.Range(0, ColorHex.Length);

        Renderer renderer = player.GetComponent<Renderer>();

        if (renderer != null)
        {
            Color color;
            ColorUtility.TryParseHtmlString(ColorHex[randomColor], out color);

            renderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
