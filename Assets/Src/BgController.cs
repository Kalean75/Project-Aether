using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whee : MonoBehaviour
{
    [SerializeField][Range(300,500)]float _offsetCooldown = 300f;
    [SerializeField][Range(0.001f, 0.010f)] float moveDampener = 0.001f;
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
        GameObject player = GameObject.FindWithTag("Player");

		offset.y += (-player.GetComponent<Rigidbody>().velocity.z * moveDampener) / _offsetCooldown;
		offset.x += (-player.GetComponent<Rigidbody>().velocity.x * moveDampener) / _offsetCooldown;
		//offset.x += Time.deltaTime / _offsetCooldown;
		_material.mainTextureOffset = offset;
    }
}
