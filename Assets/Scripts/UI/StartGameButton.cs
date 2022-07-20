using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour {
    private Button _button;
    private GameLifeCycle _gameLifeCycle;

    private void Awake() {
        if (Bootstrapper.TryGetInstance<GameLifeCycle>(out _gameLifeCycle) == false) {
            Debug.LogException(new System.Exception($"{this}: {nameof(_gameLifeCycle)} is null"));
        }

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonDown);
    }

    private void OnDestroy() {
        _button.onClick.RemoveListener(OnButtonDown);
    }

    private void OnButtonDown() {
        _gameLifeCycle.Start();
        _button.gameObject.SetActive(false);
    }
}
