using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacelcontoroll : MonoBehaviour
{
    public const string Tag = "Eenemy";// get Tag obstacels//

    private Transform tr;

    [SerializeField] float movespeed = 5;

    private void Awake()
    {
        tr = transform;
    }
    private void OnEnable()// when is on , on one of them //
    {// show random obstacels//
        int randomselected = Random.Range(0, transform.childCount-1);// we have 5 obstacels .-1 its mean one obstacels is not your child  //
        for (int i = 0; i < transform.childCount-1; i++)
            transform.GetChild(i).gameObject.SetActive(i == randomselected);// if object if true its mean show the obstacel if off dont do it //

    }
    private void Update()
    {
        tr.position -= tr.right * movespeed * Time.deltaTime;
        if (tr.position.x < ObstacleSoawner.Instance.Killpoint)
            gameObject.SetActive(false);
        
    }








}
