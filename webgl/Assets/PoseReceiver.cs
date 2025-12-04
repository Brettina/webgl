using UnityEngine;

public class PoseReceiver : MonoBehaviour
{
    public Transform target;

    public float positionLerpSpeed = 10f;
    public float rotationLerpSpeed = 10f;

    private Vector3 _targetPos;
    private Quaternion _targetRot;
    private bool _hasPose;

    void Start()
    {
        // Make sure background is transparent
        var cam = Camera.main;
        if (cam != null)
        {
            cam.clearFlags = CameraClearFlags.Depth;
            cam.backgroundColor = new Color(0f, 0f, 0f, 0f);
        }
    }

    // Called from JavaScript via SendMessage
    public void SetPose(string poseJson)
    {
        var pose = JsonUtility.FromJson<PoseData>(poseJson);

        _targetPos = new Vector3(pose.px, pose.py, pose.pz);
        _targetRot = new Quaternion(pose.qx, pose.qy, pose.qz, pose.qw);
        _hasPose = true;
    }

    void Update()
    {
        if (!_hasPose || target == null) return;

        target.position = Vector3.Lerp(
            target.position,
            _targetPos,
            Time.deltaTime * positionLerpSpeed);

        target.rotation = Quaternion.Slerp(
            target.rotation,
            _targetRot,
            Time.deltaTime * rotationLerpSpeed);
    }
}

[System.Serializable]
public class PoseData
{
    public float px, py, pz;
    public float qx, qy, qz, qw;
}

