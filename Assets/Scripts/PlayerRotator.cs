using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{

    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
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
