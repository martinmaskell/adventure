using System;
using System.Configuration;
using System.Web;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.Game;

namespace Maskell.Adventure.WebLogic.Helpers
{
	public class GameHelper
	{
		private const string DefaultGameIdKey = "DefaultGameId";
		private const string GameEngineKey = "GameEngine";

		public static IGameEngine CurrentGameEngine
		{
			get { return GetSessionObject<IGameEngine>(GameEngineKey); }
			private set { SetSessionObject(GameEngineKey, value); }
		}

		public static IGameEngine GetGame()
		{
			return GetGame(DefaultGameId);
		}

		public static IGameEngine GetGame(Guid gameId)
		{
			var gameEngine = new GameEngine();
			CurrentGameEngine = gameEngine.New(gameId) ? gameEngine : null;

			return CurrentGameEngine;
		}

		private static void SetSessionObject<T>(string key, T sessionObject)
		{
			if (HttpContext.Current == null || HttpContext.Current.Session == null)
				return;

			HttpContext.Current.Session[key] = sessionObject;
		}

		private static T GetSessionObject<T>(string key) where T : class
		{
			if (HttpContext.Current == null || HttpContext.Current.Session == null)
				return default(T);

			return HttpContext.Current.Session[key] as T;
		}

		private static Guid DefaultGameId
		{
			get
			{
				if (ConfigurationManager.AppSettings[DefaultGameIdKey] == null)
					throw new NotImplementedException("DefaultGameId has not been set");

				Guid defaultGameId;
				if (!Guid.TryParse(ConfigurationManager.AppSettings[DefaultGameIdKey], out defaultGameId))
					throw new Exception("Invalid DefaultGameId");

				return defaultGameId;
			}
		}
	}
}
