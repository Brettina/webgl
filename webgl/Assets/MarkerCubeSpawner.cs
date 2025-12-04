using UnityEngine;

public class MarkerCubeSpawner : MonoBehaviour
{
    [System.Serializable]
    class PoseData { public float px, py, pz, rx, ry, rz; }

    public GameObject cubePrefab;
    GameObject cube;

    public void OnCardPoseJson(string json)
    {
        var p = JsonUtility.FromJson<PoseData>(json);

        Vector3 pos = new Vector3(p.px, p.py, p.pz);
        Quaternion rot = Quaternion.Euler(p.rx, p.ry, p.rz);

        if (!cube) cube = Instantiate(cubePrefab);
        cube.transform.SetPositionAndRotation(pos, rot);
    }
}
