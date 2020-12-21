using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableArrow : MonoBehaviour
{
    MaterialPropertyBlock pBlock;
    new Renderer renderer;

    public float maxLength = 4;

    private void UpdateShader()
    {
        // Grab renderer and create pBlock if necessary
        if (renderer == null)
            renderer = GetComponent<Renderer>();
        if (pBlock == null)
            pBlock = new MaterialPropertyBlock();

        // Update material's property block
        renderer.GetPropertyBlock(pBlock);

        pBlock.SetFloat("_Stretch", transform.lossyScale.z);

        renderer.SetPropertyBlock(pBlock);
    }

    public void SetLength(float length)
    {
        // Check that length value is between 0 and 1
        if (length < 0 || length > 1)
            Debug.LogWarning("ExtendableArrow.SetLength(float length): length value should be between 0 and 1 (inclusive) | length = " + length);  
        length = Mathf.Clamp(length, 0, 1);

        // Calculate the proper scale
        float lossyToLocal = transform.localScale.z / transform.lossyScale.z;
        Vector3 scale = transform.localScale;
        scale.z = Mathf.Lerp(1, maxLength, length) * lossyToLocal;

        // Scale the arrow
        transform.localScale = scale;

        UpdateShader();
    }
}
