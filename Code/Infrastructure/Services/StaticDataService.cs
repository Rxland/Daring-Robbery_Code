using System.Collections.Generic;
using System.Linq;
using _GAME.Code.Data.Sound;
using _GAME.Code.Data.VFX;
using _GAME.Code.Logic.Enemy;
using _GAME.Code.Logic.Interaction;
using _GAME.Code.Logic.Weapon_Stuff;
using _GAME.Code.StaticData;
using _GAME.Code.StaticData.Shop;
using _GAME.Code.StaticData.UI;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types;
using _GAME.Code.Types.Weapon_Stuff;
using _GAME.Code.UI.Shop;
using UnityEngine;

namespace _GAME.Code.Infrastructure.Services
{
    public class StaticDataService : IService
    {
        public PlayerStaticData ReturnPlayerStaticData => _playerStaticData;
        public InteractionUiStaticData InteractionUiStaticData => _interactionUiStaticData;
        public SafeDepositStaticData SafeDepositStaticData => _safeDepositStaticData;
        public ATMStaticData ATMStaticData => _ATMStaticData;
        public ShopStaticData ShopStaticData => _shopStaticData;
        public ShopTabWeaponsStaticData ShopTabWeaponsStaticData => _shopTabWeaponsStaticData;
        public ShopTabAttachmentsStaticData ShopTabAttachmentsStaticData => _shopTabAttachmentsStaticData;
        public CustomersMainStaticData CustomersMainStaticData => _customersMainStaticData;
        public List<WeaponStaticData>  WeaponStaticDataList => _weapons;
        public InteractableObjectsSettings InteractableObjectsSettings => _interactableObjectsSettings;
        public LayerMasksStaticData LayerMasksStaticData => _layerMasksStaticData;
        public HeistStaticData HeistStaticData => _heistStaticData;
        
        
        private const string _enemiesPath = "Static Data/Enemies";
        private const string _playerPath = "Static Data/Player Static Data";
        private const string _levelsPath = "Static Data/Levels";
        private const string _InteractionUiPath = "Static Data/UI/Interaction Ui Static Data";
        private const string _vfxStaticDataPath = "Static Data/VFX Static Data";
        private const string _safeDepositStaticDataPath = "Static Data/Safe Deposit Static Data";
        private const string _ATMStaticDataPath = "Static Data/ATM Static Data";
        private const string _soundStaticDataPath = "Static Data/Sound Static Data";
        private const string _weaponsStaticDataPath = "Static Data/Weapon Stuff/Weapons";
        private const string _weaponAttachmentsStaticDataPath = "Static Data/Weapon Stuff/Weapon Attachments";
        private const string _shopWeaponTabStaticDataPath = "Static Data/Shop/Tabs/Shop Tab Weapons Static Data";
        private const string _shopAttachmentTabStaticDataPath = "Static Data/Shop/Tabs/Shop Tab Attachments Static Data";
        private const string _shopStaticDataPath = "Static Data/Shop/Shop Static Data";
        private const string _customersMainStaticDataPath = "Static Data/Customers Main Static Data";
        private const string _interactableObjectsSettingsPath = "Static Data/Interaction/InteractableObjectsSettings";
        private const string _layerMasksStaticDataPath = "Static Data/Layer Masks Static Data";
        private const string _heistStaticDataPath = "Static Data/Heist Static Data";

        
        private Dictionary<EnemyType, EnemyStaticData> _enemies;
        private Dictionary<int, LevelStaticData> _Levels;
        private List<WeaponStaticData> _weapons;
        private Dictionary<WeaponAttachmentTabType, List<WeaponAttachmentStaticData>> _weaponAttachments;
        private List<VfxStaticDataData> _vfxList;
        private PlayerStaticData _playerStaticData;
        private InteractionUiStaticData _interactionUiStaticData;
        private SafeDepositStaticData _safeDepositStaticData;
        private ATMStaticData _ATMStaticData;
        private SoundStaticData _soundStaticData;
        private ShopStaticData _shopStaticData;
        private CustomersMainStaticData _customersMainStaticData;
        private ShopTabWeaponsStaticData _shopTabWeaponsStaticData;
        private ShopTabAttachmentsStaticData _shopTabAttachmentsStaticData;
        private InteractableObjectsSettings _interactableObjectsSettings;
        private LayerMasksStaticData _layerMasksStaticData;
        private HeistStaticData _heistStaticData;
        
        
        public void Init()
        {
            Load();
        }
        
        private void Load()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(_enemiesPath)
                .ToDictionary(x => x.EnemyType, x => x);
            
            _Levels = Resources
                .LoadAll<LevelStaticData>(_levelsPath)
                .ToDictionary(x => x.Level_Id, x => x);

            _weapons = new List<WeaponStaticData>(Resources.LoadAll<WeaponStaticData>(_weaponsStaticDataPath));
            
            _weaponAttachments = Resources
                .LoadAll<WeaponAttachmentStaticData>(_weaponAttachmentsStaticDataPath)
                .GroupBy(x => x.weaponAttachmentTabType)
                .ToDictionary(x => x.Key, x => x.ToList());
            
            _shopTabWeaponsStaticData = Resources.Load<ShopTabWeaponsStaticData>(_shopWeaponTabStaticDataPath);
            _shopTabAttachmentsStaticData = Resources.Load<ShopTabAttachmentsStaticData>(_shopAttachmentTabStaticDataPath);
            
            _vfxList = Resources.Load<VfxStaticData>(_vfxStaticDataPath).VfxDataList;

            _playerStaticData = Resources.Load<PlayerStaticData>(_playerPath);
            _interactionUiStaticData = Resources.Load<InteractionUiStaticData>(_InteractionUiPath);
            _safeDepositStaticData = Resources.Load<SafeDepositStaticData>(_safeDepositStaticDataPath);
            _ATMStaticData = Resources.Load<ATMStaticData>(_ATMStaticDataPath);
            _soundStaticData = Resources.Load<SoundStaticData>(_soundStaticDataPath);
            _shopStaticData = Resources.Load<ShopStaticData>(_shopStaticDataPath);
            _customersMainStaticData = Resources.Load<CustomersMainStaticData>(_customersMainStaticDataPath);
            _interactableObjectsSettings = Resources.Load<InteractableObjectsSettings>(_interactableObjectsSettingsPath);
            _layerMasksStaticData = Resources.Load<LayerMasksStaticData>(_layerMasksStaticDataPath);
            _heistStaticData = Resources.Load<HeistStaticData>(_heistStaticDataPath);
        }

        public EnemyStaticData ReturnEnemyStaticDataByType(EnemyType enemyType) => 
            _enemies.TryGetValue(enemyType, out EnemyStaticData enemyStaticData) ? enemyStaticData : null;

        public LevelStaticData ReturnLevelStaticDataById(int id) => 
            _Levels.TryGetValue(id, out LevelStaticData levelStaticData) ? levelStaticData : null;
        
        public List<WeaponAttachmentStaticData> ReturnWeaponAttachmentStaticDataList(WeaponAttachmentTabType weaponAttachmentTabType) => 
            _weaponAttachments.TryGetValue(weaponAttachmentTabType, out List<WeaponAttachmentStaticData> weaponAttachmentStaticDataList) 
                ? weaponAttachmentStaticDataList : null;
        
        
        public ParticleSystem ReturnEffectByType(VfxType vfxType)
        {
            foreach (VfxStaticDataData vfxStaticDataData in _vfxList)
            {
                if (vfxStaticDataData.VfxType == vfxType)
                    return vfxStaticDataData.EffectPrefab;
            }
            return null;
        }
        public AudioSource ReturnAudioSourcePrefabByName(SoundName soundName)
        {
            foreach (SoundStaticDataData soundStaticDataData in _soundStaticData.SoundList)
            {
                if (soundStaticDataData.SoundName == soundName)
                    return soundStaticDataData.AudioSourcePrefab;
            }
            return null;
        }

    }
}