using UnityEngine;

public class healthGUI : MonoBehaviour
{
    private HealthController _playerHealth;

    private void Start()
    {
        _playerHealth = gameObject.GetComponent<HealthController>();
    }

#if UNITY_EDITOR
    private void OnGUI()
    {

        GUI.Box(new Rect(0, 0, 40, 20), _playerHealth.Health.ToString());

        GUI.Box(new Rect(0, 25, _playerHealth.Health, 20), "");
    }
#endif
}
