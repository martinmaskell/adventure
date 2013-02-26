using System;
using System.Configuration;

namespace Maskell.DataAccess.Common
{
	public class DataContext<T> where T : System.Data.Linq.DataContext
	{
// ReSharper disable StaticFieldInGenericType
		static readonly string _connectionString = ConfigurationManager.ConnectionStrings["AdventureConnectionString"].ConnectionString;
// ReSharper restore StaticFieldInGenericType

		public static T TrackedContext
		{

			get
			{
				return CreateContext(true);
			}

		}

		public static T UnTrackedContext
		{

			get
			{
				return CreateContext(false);
			}
		}

		private static T CreateContext(bool tracked)
		{
			T dataContext = (T)Activator.CreateInstance(typeof(T), new object[] { _connectionString });
			dataContext.ObjectTrackingEnabled = tracked;

			return dataContext;
		}

		public static void KillContext(T dataContext)
		{
			dataContext.Connection.Close();
			dataContext.Connection.Dispose();
			dataContext.Dispose();
		}
	}
}
