using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomPos : MonoBehaviour
{
    public GameObject Prefab; // Prefab
    public Vector3 AreaCenter; // Tâm của khu vực sinh ngẫu nhiên
    public Vector3 AreaSize;
    // Start is called before the first frame update
    void Start()
    {
        string[] ColorHex = new string[] { "#2F396C", "#FFDB55", "#CA1212" };


        // Sinh ngẫu nhiên item 
        for (int i = 0; i < ColorHex.Length; i++)
        {
            // Tạo vị trí ngẫu nhiên trong khu vực sinh ngẫu nhiên
            Vector3 randomSpawnPosition = AreaCenter + new Vector3(Random.Range(-AreaSize.x / 2, AreaSize.x / 2),
                                                                       AreaSize.y,
                                                                       Random.Range(-AreaSize.z / 2, AreaSize.z / 2));
         
            GameObject colector = Instantiate(Prefab, randomSpawnPosition, Quaternion.identity);
        
            Renderer renderer = colector.GetComponent<Renderer>();

            Color color;
            ColorUtility.TryParseHtmlString(ColorHex[i], out color);

            if (renderer != null)
            {
                Debug.Log("true");
                renderer.material.color = color; 
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
