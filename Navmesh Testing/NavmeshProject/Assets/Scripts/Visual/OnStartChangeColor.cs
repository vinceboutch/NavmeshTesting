using UnityEngine;

namespace Visual
{
    public class OnStartChangeColor : MonoBehaviour
    {
        private MeshRenderer meshRenderer;

        private static readonly Color[] COLORS = new Color[]
            {Color.blue, Color.cyan, Color.gray, Color.green, Color.red, Color.white, Color.yellow, Color.magenta};

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            if (meshRenderer == null)
            {
                Debug.Log("SkinnedMeshRenderer not found!");
            }
        }

        private void Start()
        {
            meshRenderer.material.SetColor("_Color", COLORS[GetRandomColorIndex()]);
        }

        private int GetRandomColorIndex()
        {
            return Random.Range(0, COLORS.Length);
        }
    }
}