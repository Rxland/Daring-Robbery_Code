using System;
using System.Collections;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Env.Level;
using _GAME.Code.UI.Canvases;
using Zenject;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GAME.Code.Infrastructure.Factories
{
    public class EnvFactory : IService
    {
        public Level Level => _level;
        public Action LevelLoadedAction;

        private Level _level;
        
        [Inject] private StaticDataService _staticDataService;
        [Inject] private CanvasesController _canvasesController;
        [Inject] private DiContainer _diContainer;
        [Inject] private ZenjectSceneLoader _zenjectSceneLoader;
        
        
        public IEnumerator SpawnLevel(int levelId)
        {
            _canvasesController.OpenCanvas(CanvasType.LoadingCanvas);

            AsyncOperation asyncLoad = _zenjectSceneLoader.LoadSceneAsync($"Level_{levelId}", LoadSceneMode.Additive,
                container => { }, LoadSceneRelationship.Child);
            
            LoadingScreenCanvas loadingScreenCanvas = (LoadingScreenCanvas)_canvasesController.CurrentCanvas;
            
            while (!asyncLoad.isDone)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

                loadingScreenCanvas.LoadingBarFilledImg.fillAmount = progress;

                yield return null;
            }
            _level = GameObject.FindObjectOfType<Level>();
            
            LevelLoadedAction?.Invoke();
        }
    }
}