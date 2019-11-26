using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public Color hoverColor;
    private GameObject turret;
    private Renderer r;
    private Color startColor;

    private void Start()
    {
        r = GetComponent<Renderer>();
        startColor = r.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            r.material.color = Color.red;
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (turret != null)
        {
            r.material.color = Color.red;
            return;
        }

        r.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        r.material.color = startColor;
    }
}
