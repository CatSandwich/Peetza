using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    private void Start() => gameObject.SetActive(false);
}
