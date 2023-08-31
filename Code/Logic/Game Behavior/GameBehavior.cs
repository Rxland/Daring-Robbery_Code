using System;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Camera_Logic;
using _GAME.Code.UI;
using _GAME.Code.UI.Canvases;
using _GAME.Code.UI.Top_Navigation;
using _GAME.Code.UI.Windows;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _GAME.Code.Logic.Game_Behavior
{
    public class GameBehavior : MonoBehaviour
    {
        [Inject] [ReadOnly] public StaticDataService StaticDataService;
        [Inject] [ReadOnly] public EnemyFactory EnemyFactory;
        [Inject] [ReadOnly] public GameFactory GameFactory;
        [Inject] [ReadOnly] public EnvFactory EnvFactory;
        [Inject] [ReadOnly] public UiFactory UiFactory;
        [Inject] [ReadOnly] public InteractionUiFeature interactionUiFeature;
        [Inject] [ReadOnly] public HudUiFeature HudUiFeature;
        [Inject] [ReadOnly] public InventoryFeature InventoryFeature;
        [Inject] [ReadOnly] public TopNavigation TopNavigation;
        [Inject] [ReadOnly] public SaveFeature SaveFeature;
        [Inject] [ReadOnly] public RunTimeDataFeature RunTimeDataFeature;
        
        [FormerlySerializedAs("WindowsController")]
        [Inject] [ReadOnly] public MainMenuWindowsController mainMenuWindowsController;
        [Inject] [ReadOnly] public MainMenuWindow MainMenuWindow;
        [Inject] [ReadOnly] public CameraLogic CameraLogic;
        [Inject] [ReadOnly] public CanvasesController CanvasesController;
        [Inject] [ReadOnly] public SettingsFeature SettingsFeature;
        [Inject] [ReadOnly] public UiFeature UiFeature;
        
        // public Action LoadLevelAction;
        public bool IsGameLoaded;
        public bool IsLevelStartLoading;
        public bool IsHeistStarted;
        
        private void Awake()
        {
            StaticDataService.Init();
        }
    }
}