using System;
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
        private bool _fixesHaveBeenApplied = false;
    
        void Start()
        {
            _uiDocument = GetComponent<UIDocument>();
        
            _playButton = _uiDocument.rootVisualElement.Q<Button>("Play");
            _quitButton = _uiDocument.rootVisualElement.Q<Button>("Quit");
        
            _playButton.clicked += OnPlayButtonClicked;
            _quitButton.clicked += OnQuitButtonClicked;
        }

        private void OnGUI()
        {
            if (!_fixesHaveBeenApplied)
            {
                UssVisualFixes();
            }
        }

        private void UssVisualFixes()
        {
            // Elements with .menu-btn .icon
            var buttonsIcons = _uiDocument.rootVisualElement.Query<VisualElement>(null, "btn-icon");
            
            // Well set the height px value to the width px value
            buttonsIcons.ForEach(buttonIcon =>
            {
                var buttonIconHeight = buttonIcon.resolvedStyle.height;
                
                if (buttonIconHeight < 40.0f)
                {
                    buttonIconHeight = 40.0f;
                    buttonIcon.style.height = buttonIconHeight;
                }
                
                buttonIcon.style.width = buttonIconHeight;
            });
            
            _fixesHaveBeenApplied = true;
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
