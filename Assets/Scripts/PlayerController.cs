using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Mover mover;
    [SerializeField] Shooter shooter;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] CinemachineVirtualCamera focusCamera;

    public void Fire()
    {
        shooter.Fire();
        audioPlayer.PlayFire();
        animator.SetTrigger("Fire");
        Manager.Data.totalFireCount++;
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        mover.SetDir(new Vector3(input.x, 0, input.y));

        if (input.sqrMagnitude > 0)
        {
            audioPlayer.PlayDrive();
        }
        else
        {
            audioPlayer.PlayIdle();
        }
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Fire();
        }
    }

    private void OnFocus(InputValue value)
    {
        focusCamera.Priority = value.isPressed ? 20 : 5;
    }
}
