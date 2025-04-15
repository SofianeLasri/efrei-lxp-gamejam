using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Ui
{
    public class Menu : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private Button _playButton;
        private Button _quitButton;
    
        void Start()
        {
            _uiDocument = GetComponent<UIDocument>();
        
            _playButton = _uiDocument.rootVisualElement.Q<Button>("Play");
            _quitButton = _uiDocument.rootVisualElement.Q<Button>("Quit");
        
            _playButton.clicked += OnPlayButtonClicked;
            _quitButton.clicked += OnQuitButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(1);
        }

        private void OnQuitButtonClicked()
        {
            Application.Quit();
        }
    }
}
