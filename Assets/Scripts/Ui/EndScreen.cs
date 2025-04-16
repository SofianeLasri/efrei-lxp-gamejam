using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Ui
{
    public class EndScreen : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private Button _playButton;
        
        void Start()
        {
            _uiDocument = GetComponent<UIDocument>();
        
            _playButton = _uiDocument.rootVisualElement.Q<Button>("Play");
        
            _playButton.clicked += OnPlayButtonClicked;
        }
        
        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(1);
        }
    }
}