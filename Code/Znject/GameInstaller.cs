using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Camera_Logic;
using _GAME.Code.Logic.Game_Behavior;
using _GAME.Code.Logic.Weapon_Stuff;
using _GAME.Code.UI;
using _GAME.Code.UI.Canvases;
using _GAME.Code.UI.Shop;
using _GAME.Code.UI.Top_Navigation;
using _GAME.Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Znject
{
    public class GameInstaller : MonoInstaller
    {
        public GameBehavior GameBehavior;
        [Space]
        
        public InteractionsUiRef InteractionsUiRef;
        public SaveFeature SaveFeature;
        public RunTimeDataFeature RunTimeDataFeature;
        public UiFeature UiFeature;
        public WeaponPreview WeaponPreview;
        
        [Header("Ui")]
        public TopNavigation TopNavigation;
        public HudUiRef hudUiRef;
        public MainMenuWindow MainMenuWindow;
        public CameraLogic CameraLogic;
        
        public MainMenuWindowsController MainMenuWindowsController;
        public CanvasesController CanvasesController;
        
        
        public override void InstallBindings()
        {
            Container.Bind<VfxFactory>().AsSingle().NonLazy();
            Container.Bind<EnemyFactory>().AsSingle().NonLazy();
            Container.Bind<EnvFactory>().AsSingle().NonLazy();
            Container.Bind<GameFactory>().AsSingle().NonLazy();
            Container.Bind<UiFactory>().AsSingle().NonLazy();
            Container.Bind<SoundFactory>().AsSingle().NonLazy();

            Container.Bind<ShopSaveHandler>().AsSingle().NonLazy();
            
            Container.Bind<HudUiFeature>().AsSingle().NonLazy();
            Container.Bind<InventoryFeature>().AsSingle().NonLazy();
            Container.Bind<WeaponsFeature>().AsSingle().NonLazy();
            Container.Bind<InteractionUiFeature>().AsSingle().NonLazy();
            Container.Bind<PlayerProgressFeature>().AsSingle().NonLazy();
            Container.Bind<SettingsFeature>().AsSingle().NonLazy();
            
            Container.Bind<StaticDataService>().AsSingle().NonLazy();

            Container.Bind<RunTimeDataFeature>().FromInstance(RunTimeDataFeature).AsSingle().NonLazy();
            Container.Bind<UiFeature>().FromInstance(UiFeature).AsSingle().NonLazy();
            Container.Bind<InteractionsUiRef>().FromInstance(InteractionsUiRef).AsSingle().NonLazy();
            Container.Bind<HudUiRef>().FromInstance(hudUiRef).AsSingle().NonLazy();
            Container.Bind<SaveFeature>().FromInstance(SaveFeature).AsSingle().NonLazy();
            Container.Bind<WeaponPreview>().FromInstance(WeaponPreview).AsSingle().NonLazy();
            Container.Bind<TopNavigation>().FromInstance(TopNavigation).AsSingle().NonLazy();
            Container.Bind<GameBehavior>().FromInstance(GameBehavior).AsSingle().NonLazy();
            Container.Bind<MainMenuWindow>().FromInstance(MainMenuWindow).AsSingle().NonLazy();
            Container.Bind<CameraLogic>().FromInstance(CameraLogic).AsSingle().NonLazy();
            
            Container.Bind<MainMenuWindowsController>().FromInstance(MainMenuWindowsController).AsSingle().NonLazy();
            Container.Bind<CanvasesController>().FromInstance(CanvasesController).AsSingle().NonLazy();
        }
    }
}