using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreManager : MonoBehaviour
{
    private Queue<GameObject> ores = new Queue<GameObject>();

    private int oreMaxCapacity = 3;

    public GameObject CurrentOreTarget { get; private set; }

    public void LookForOre()
    {
        CurrentOreTarget = GameObject.Find("Ore");
    }

    public void GrabOre(GameObject ore)
    {
        if(ore.CompareTag("Ore") == false)
            return;

        if (ores.Count >= oreMaxCapacity)
            return;

        if ((ore.transform.position - this.transform.position).magnitude > 1f)
            return;

        ore.transform.parent = this.transform;
        ore.transform.localPosition = Vector3.up * ores.Count;
        ores.Enqueue(ore);
    }

    public void DropOre(Vector3 dropLocation)
    {
        if (ores.Count <= 0)
            return;

        GameObject ore = ores.Dequeue();

        ore.transform.parent = null;

        ore.transform.position = dropLocation;
    }
}
