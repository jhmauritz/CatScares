using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public float speed = 1f;

    private MeshRenderer meshRenderer;
    private Vector2 savedOffset;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        savedOffset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        float x = Time.time * speed;
        Vector2 offset = new Vector2(x, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
