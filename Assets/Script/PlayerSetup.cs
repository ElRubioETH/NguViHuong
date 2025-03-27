using UnityEngine;
using Fusion;

public class PlayerSetup : NetworkBehaviour
{
    public void SetupCamera()
    {
        if (Object.HasStateAuthority)
        {
            var cameraFollow = FindFirstObjectByType<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.AssignCamera(transform);
            }
        }
    }
    public void SetupStats()
    {

    }

}
