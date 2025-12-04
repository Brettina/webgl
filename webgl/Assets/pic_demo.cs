using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pic_demo : MonoBehaviour
{
    public GameObject[] objectsToRotate;
    public Transform pivot;
    public float speed = 30f;
    public float mind = 1f;
    public float maxd = 3f;

    Vector3[] orbitOffsets;

    void Start()
    {
        if (pivot == null || objectsToRotate == null) return;

        orbitOffsets = new Vector3[objectsToRotate.Length];

        // Assign random distance + random starting angle
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            GameObject obj = objectsToRotate[i];
            if (obj == null) continue;

            float distance = Random.Range(mind, maxd);
            float angle = Random.Range(0f, 360f);

            // Convert angle/distance to a position around the pivot
            Vector3 offset = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                0f,
                Mathf.Sin(angle * Mathf.Deg2Rad)
            ) * distance;

            orbitOffsets[i] = offset;

            // Place object at its randomized offset
            obj.transform.position = pivot.position + offset;
        }
    }

    void Update()
    {
        if (pivot == null || objectsToRotate == null) return;

        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            GameObject obj = objectsToRotate[i];
            if (obj == null) continue;

            // Rotate offset vector around Y-axis
            orbitOffsets[i] = Quaternion.Euler(0f, speed * Time.deltaTime, 0f) * orbitOffsets[i];

            // Apply new position
            obj.transform.position = pivot.position + orbitOffsets[i];
        }
    }
}
