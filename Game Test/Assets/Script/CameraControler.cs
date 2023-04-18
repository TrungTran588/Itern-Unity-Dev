using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform target; // Đối tượng theo dõi
    public Vector3 offset; // Độ lệch vị trí giữa camera và đối tượng theo dõi
    public float rotationDamping = 2.0f; // Tốc độ quay của camera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationDamping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);

    }
}
