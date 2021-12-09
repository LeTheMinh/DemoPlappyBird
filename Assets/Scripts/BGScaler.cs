using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;// 1 1 1

        float height = sr.bounds.size.y;  //bien y
        float wight = sr.bounds.size.x;    //bien x

        float worldHeight = Camera.main.orthographicSize * 2f;  //10
        float worldWidth = worldHeight * Screen.width / Screen.height;

        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / wight;
        transform.localScale = tempScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
