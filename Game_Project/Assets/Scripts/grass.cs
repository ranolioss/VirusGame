using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{

    [SerializeField] Transform[] items;
    [SerializeField] float movespeed = 5;

    [Space(4)]

    [SerializeField] float bornpoint = 38;
    [SerializeField] float killpoint = -28;

    private void Awake()
    {
        items = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            items[i] = transform.GetChild(i);
        }

    }

    private void Update()
    {

        for (int i = 0; i < items.Length; i++)
        {

            items[i].position -= items[i].right * movespeed * Time.deltaTime;

            if (items[i].position.x < killpoint)
            {
                items[i].position = new Vector2(bornpoint - 3, 0);
                items[i].position -= items[i].right * movespeed * Time.deltaTime;
            }
        }
    }
}

