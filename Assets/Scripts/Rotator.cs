using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        Vector2 scale = transform.localScale;
        if (dir.x > 0)
        {
            scale.x = 1;

        }
        else if (dir.x < 0)
        {
            scale.x = -1f;
        }
        transform.localScale = scale;
    }

}
