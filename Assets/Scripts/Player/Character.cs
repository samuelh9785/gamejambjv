using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform otherPlayer = default;
    [SerializeField] private Transform laser = default;
    [SerializeField] private int health = 3;
    [SerializeField] private float timeChargeLaser = 2f;
    [SerializeField] private float laserSpeed = 2f;

    private float timerLaser;
    private bool isShooting = false;
    private float currentSize = 0;

    private void Start()
    {
        otherPlayer = GameObject.Find("Yes").transform;
    }

    private void Update()
    {
        if (LoadLaser()) ShootLaser();
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
        ResetLaser();
        timerLaser = 0;
        return true;
    }

    public void ResetLaser()
    {
        currentSize = 0;
        laser.localScale = new Vector3(currentSize, laser.localScale.y, 1);
    }

    private void ShootLaser()
    {
        laser.localScale = new Vector3(currentSize, laser.localScale.y, 1);
        currentSize += Time.deltaTime * laserSpeed;
    }

    private void LateUpdate()
    {
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
