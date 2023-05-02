using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 posOffset;

    public GameObject turret;

    private Renderer _renderer;
    private Color _startColor;
    
    void Start ()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }
    void OnMouseDown ()
    {
        if (turret != null)
        {
            Debug.Log("Can not build here!!");
            return;
        }
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position+posOffset,
            transform.rotation);
    }
    void OnMouseEnter ()
    {
        _renderer.material.color = notEnoughMoneyColor;
    }
    void OnMouseExit ()
    {
        _renderer.material.color = _startColor;
    }
}
