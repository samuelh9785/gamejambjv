using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform otherPlayer = default;
    [SerializeField] private int health = 3;

    private void LateUpdate()
    {
        Vector3 diff = otherPlayer.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float finalRotation = rot_z - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, finalRotation);
    }
}
