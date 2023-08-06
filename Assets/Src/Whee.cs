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
        int num = Random.Range(-2, 2);
        if(num == 1)
        {
			offset.y += Time.deltaTime / _offsetCooldown;
		}
		if (num == -1)
		{
			offset.y -= Time.deltaTime / _offsetCooldown;
		}
		if (num == 2)
        {
			offset.x += Time.deltaTime / _offsetCooldown;
		}
		if (num == -2)
		{
			offset.x -= Time.deltaTime / _offsetCooldown;
		}
		_material.mainTextureOffset = offset;
    }
}
