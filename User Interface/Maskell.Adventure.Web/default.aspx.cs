using System;
using System.Web.UI;
using Maskell.Adventure.DomainEntities;
using Maskell.Adventure.DomainEntities.Interfaces;
using Maskell.Adventure.WebLogic.Helpers;

namespace Maskell.Adventure.Web
{
	public partial class _default : Page
	{
		private static IGameEngine Engine
		{
			get
			{
				return GameHelper.CurrentGameEngine;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				InitialiseGame();

			ltlGameTitle.Text = Engine.GameTitle;
			ltlGameDescription.Text = Engine.GameDescription;

		}

		private static void InitialiseGame()
		{
			GameHelper.GetGame();
		}

		protected void btnStart_Click(object sender, EventArgs e)
		{
			Engine.GameStarted += GameEngine_GameStarted;
			Engine.StartNewGame();
		}

		void GameEngine_GameStarted(object sender, GameResponseEventArgs e)
		{
			pnlGameInfo.Visible = false;

			ltlLocationDescription.Text = e.LocationDescription;
			ltlCommandResponseMessage.Text = e.Response;
			
			pnlGame.Visible = true;
		}

		protected void btnExecuteCommand_Click(object sender, EventArgs e)
		{
			Engine.ProcessCommand(txtCommand.Text);

			txtCommand.Text = string.Empty;

			ltlCommandResponseMessage.Text = Engine.CommandResponse;
			ltlLocationDescription.Text = Engine.GameDescription;
		}

	}
}