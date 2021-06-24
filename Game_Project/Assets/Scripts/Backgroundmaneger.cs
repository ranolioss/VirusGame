using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmaneger : MonoBehaviour
{    // we use SerializeField just show it in editor//
    [SerializeField]  Transform[] items;
    [SerializeField]  float movespeed = 5;

    [Space(4)]// space with varibale up and down //

    [SerializeField] float bornpoint = 48;// last child//
    [SerializeField] float killpoint = -24;//when the background reach in position -25 update the background//

    private void Awake()
    {
        items = new Transform[transform.childCount];// create array child tarnsfrom//
        for (int i = 0; i < transform.childCount; i++)//for all child and  get child scripts//
        {
            items[i] = transform.GetChild(i);// show the child //
        }
            
    }

    private void Update()
    {
      
        for (int i = 0; i < items.Length; i++)// get items//
        {
            
            items[i].position -= items[i].right * movespeed * Time.deltaTime;

            if (items[i].position.x < killpoint)
            {
                items[i].position = new Vector2(bornpoint -3 , 0);
                items[i].position-= items[i].right * movespeed * Time.deltaTime;
                // when you reach in born  point go to for . this step make remove space from each back //
            }
        }
    }
}
