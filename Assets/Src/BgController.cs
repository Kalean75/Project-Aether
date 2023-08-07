using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whee : MonoBehaviour
{
    [SerializeField][Range(300,500)]float _offsetCooldown = 300f;
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

		offset.y += (-player.transform.position.z*0.001f) / _offsetCooldown;
		offset.x += (-player.transform.position.x * 0.001f) / _offsetCooldown;
		//offset.x += Time.deltaTime / _offsetCooldown;
		//_material.mainTextureOffset = offset;
    }
}
