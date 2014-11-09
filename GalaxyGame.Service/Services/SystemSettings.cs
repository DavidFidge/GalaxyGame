using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Interfaces;

namespace GalaxyGame.Service.Services
{
    public class SystemSettings : BaseService, ISystemSettings
    {
        public SystemSettings(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        private T GetSystemSetting<T>(string propertyName, T defaultValue)
        {
            var uow = _unitOfWorkFactory.Create();

            var settingValue = defaultValue;

            var setting = uow.Context.DbSet<SystemSetting>().FirstOrDefault(ss => ss.Name == propertyName);

            if (setting != null)
                settingValue = (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(setting.Value);

            _unitOfWorkFactory.Release();

            return settingValue;
        }

        public int MinSolarSystemsInGalaxySector
        {
            get { return GetSystemSetting(MethodBase.GetCurrentMethod().Name.Replace("get_", ""), 1); }
        }

        public int MaxSolarSystemsInGalaxySector
        {
            get { return GetSystemSetting(MethodBase.GetCurrentMethod().Name.Replace("get_", ""), 5); }
        }

        public int MinPlanetsInSystem
        {
            get { return GetSystemSetting(MethodBase.GetCurrentMethod().Name.Replace("get_", ""), 0); }
        }

        public int MaxPlanetsInSystem
        {
            get { return GetSystemSetting(MethodBase.GetCurrentMethod().Name.Replace("get_", ""), 10); }
        }
    }
}