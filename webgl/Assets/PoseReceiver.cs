using UnityEngine;

public class PoseReceiver : MonoBehaviour
{
    public Transform target;

    // Called from JavaScript via SendMessage
    public void SetPose(string poseJson)
    {
        PoseData pose = JsonUtility.FromJson<PoseData>(poseJson);

        target.position = new Vector3(
            pose.px, pose.py, pose.pz
        );

        target.rotation = new Quaternion(
            pose.qx, pose.qy, pose.qz, pose.qw
        );
    }
}

[System.Serializable]
public class PoseData
{
    public float px, py, pz;
    public float qx, qy, qz, qw;
}
