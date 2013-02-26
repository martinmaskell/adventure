using System;
using System.Linq;
using System.Reflection;
using Maskell.Adventure.Command.Interfaces;
using Maskell.Adventure.Common.Interfaces;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.DTO;

namespace Maskell.Adventure.Command.Processors
{
	public class DependencyTypeProcessor : IDependencyTypeProcessor
	{
		private readonly IGameDataManager _gameDataManager;
		public DependencyTypeProcessor(IGameDataManager gameDataManager)
		{
			_gameDataManager = gameDataManager;
		}

		public bool ProcessDependency(DependencyDto dependency)
		{
			if (dependency == null)
				throw new ArgumentNullException("dependency", "Dependency is null");

			var dependencyProcessMethod =
				GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(
					m =>
					{
						var dependencyTypeAttribute = (DependencyTypeAttribute)m.GetCustomAttributes(typeof(DependencyTypeAttribute), false).FirstOrDefault();
						return dependencyTypeAttribute != null && (dependencyTypeAttribute.DependencyType == dependency.DependencyType);
					}).FirstOrDefault();

			if (dependencyProcessMethod == null)
				return false;

			return (bool)dependencyProcessMethod.Invoke(this, new object[] { dependency });

			
		}

		[DependencyTypeAttribute(DependencyType.DirectionIsAvailable)]
		internal bool ProcessDependencyDirectionIsAvailable(DependencyDto dependency)
		{
			if (dependency == null)
				throw new ArgumentNullException("dependency", "Dependency is null");

			if (!dependency.ElementId.HasValue)
				return false;

			return _gameDataManager.CurrentLocation.Directions.Where(d => d.Identity == dependency.ElementId.Value).Count() > 0;
		}

		[DependencyTypeAttribute(DependencyType.DirectionIsNotAvailable)]
		internal bool ProcessDependencyDirectionIsNotAvailable(DependencyDto dependency)
		{
			throw new NotImplementedException();
		}

	}

	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	internal sealed class DependencyTypeAttribute : Attribute
	{
		private readonly DependencyType _dependencyType;

		public DependencyTypeAttribute(DependencyType dependencyType)
		{
			_dependencyType = dependencyType;
		}

		public DependencyType DependencyType
		{
			get { return _dependencyType; }
		}

	}
}
