using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;

    public override void FixedUpdateNetwork()
    {
        // Kiểm tra xem có phải là người chơi đang điều khiển không
        if (!Object.HasStateAuthority) return;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.fixedDeltaTime);
    }
}
