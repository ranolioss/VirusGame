using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSoawner : MonoBehaviour
{
    public static ObstacleSoawner Instance { private set; get; }
     
    [SerializeField] Obstacelcontoroll obstacelPrefab;
    [SerializeField] int itemcount = 10;
    private Transform[] items;

    [Space(5)]

    [SerializeField] float ratespam;
    private float lastspamtime;

    [Space(3)]

    [SerializeField] float bornpoint = 12;
    [SerializeField] float killpoint = -12;
    public float Killpoint { get { return killpoint; } }
    public bool playing  {set ;get; }
    private void Awake()
    {
        Instance = this;
        items = new Transform[itemcount];
        for (int i = 0; i < items.Length; i++)
        {
            (items[i] = Instantiate(obstacelPrefab.gameObject,transform).transform).gameObject.SetActive(false);
        }
    }

    private void Update()

    { if (!playing) return;
        if (lastspamtime + ratespam < Time.time)
        {
            lastspamtime = Time.time;
            for (int i = 0; i < itemcount; i++)
                if (!items[i].gameObject.activeSelf)
                {
                    items[i].gameObject.SetActive(true);
                    items[i].position = new Vector2(bornpoint, 0);
                    break;
                }
        }
    }
}
