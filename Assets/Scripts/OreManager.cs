using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreManager : MonoBehaviour
{
    [SerializeField] private Transform baseBuilding;

    public Vector3 baseBuildingLocation => baseBuilding.position;

    private Queue<GameObject> ores = new Queue<GameObject>();

    private int oreMaxCapacity = 3;

    public GameObject CurrentOreTarget { get; private set; }

    public void LookForOre()
    {
        CurrentOreTarget = GameObject.Find("Ore");
    }

    public void GrabOre()
    {
        if (ores.Count >= oreMaxCapacity)
            return;

        if ((CurrentOreTarget.transform.position - this.transform.position).magnitude > 1f)
            return;

        CurrentOreTarget.transform.parent = this.transform;
        ores.Enqueue(CurrentOreTarget);
        CurrentOreTarget.transform.localPosition = Vector3.up * ores.Count;
        

        CurrentOreTarget = null;
    }

    public bool IsCarryingOre()
    {
        return ores.Count > 0;
    }

    public void DropOre()
    {
        if (ores.Count <= 0)
            return;

        GameObject ore = ores.Dequeue();

        ore.transform.parent = null;

        ore.transform.position = baseBuildingLocation;

        ore.name = "Collected ore";
    }

    public bool IsOreTargetCloseEnough()
    {
        if (CurrentOreTarget == null)
            return false;

        return (transform.position - CurrentOreTarget.transform.position).magnitude < 0.5f;
    }

    public bool IsBaseCloseEnough()
    {
        return (transform.position - baseBuildingLocation).magnitude <= 2f;
    }
}
