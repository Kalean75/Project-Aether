using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whee : MonoBehaviour
{
    [SerializeField] float _offsetCooldown = 30f;
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer> ().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = _material.mainTextureOffset;

        offset.x += Time.deltaTime / _offsetCooldown;
        _material.mainTextureOffset = offset;
    }
}
