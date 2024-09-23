using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputeable
{
    public static InputKeyboardListener Instance;

    public delegate void HasShoot();
    public event HasShoot OnHasShoot;

    private void Awake()
    {
        Instance = this;
    }

    public void ShootPressed()
    {
        OnHasShoot?.Invoke();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            ShootPressed();
        }
    }
}
