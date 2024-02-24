using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Mover mover;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] CinemachineVirtualCamera focusCamera;

    [Header("Event")]
    public UnityEvent OnFiring;
    public UnityEvent OnFired;

    public void Fire()
    {
        OnFiring?.Invoke();
        Manager.Data.totalFireCount++;
        OnFired?.Invoke();
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
