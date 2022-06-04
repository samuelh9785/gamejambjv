using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform otherPlayer = default;
    [SerializeField] private LaserBehaviour laser = default;
    [SerializeField] private int health = 3;
    [SerializeField] private float timeChargeLaser = 2f;
    

    private float timerLaser;
    private bool isShooting = false;

    private void Update()
    {
        if (LoadLaser()) laser.ShootLaser();
    }

    private bool LoadLaser()
    {
        if (isShooting)
        {
            if (timerLaser > timeChargeLaser)
                return true;
            else
            {
                timerLaser += Time.deltaTime;
                return false;
            }
        }

        laser.ResetLaser();
        timerLaser = 0;
        return true;
    }
    

    private void LateUpdate()
    {
        if (otherPlayer == null) return;

        Vector3 diff = otherPlayer.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float finalRotation = rot_z - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, finalRotation);
    }


    void OnShoot()
    {
        Debug.Log("test on press");
        isShooting = true;
    }

    void OnShootRelease()
    {
        Debug.Log("test on release");
        isShooting = false;
    }
}
