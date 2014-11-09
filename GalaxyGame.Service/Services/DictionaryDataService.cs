using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using GalaxyGame.Core.Extensions;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.Model.Extensions;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Interfaces;

namespace GalaxyGame.Service.Services
{
    public class DictionaryDataService : BaseService, IDictionaryDataService
    {
        private readonly IRandomization _randomization;
        private readonly List<string> _latinDictionary;

        public DictionaryDataService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IRandomization randomization)
            : base(unitOfWorkFactory)
        {
            _randomization = randomization;
            _latinDictionary = File.ReadAllLines(@"data\latin.txt").ToList();
        }

        public string GetRandomLatinName(int nameSize)
        {
            var name = string.Empty;

            for (int i = 0; i < nameSize; i++)
            {
                if (i > 0)
                    name += " ";
                name += _latinDictionary[_randomization.Rand(0, _latinDictionary.Count - 1)];
            }

            return name;
        }
    }
}