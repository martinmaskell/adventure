using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor
{
	public partial class Form1 : Form
	{
		private readonly AdventureEntities _dataContext;

		public Form1()
		{
			InitializeComponent();

			_dataContext = new AdventureEntities();
		}

		~Form1()
		{
			if (_dataContext != null)
				_dataContext.Dispose();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadGames();
		}

		private void LoadGames()
		{
			List<Game> games = _dataContext.Games.ToList();

			games.Insert(0, new Game { GameID = Guid.Empty, Title = "n/a" });

			ddlGames.DataSource = games;

			ddlGames.DisplayMember = "Title";
			ddlGames.ValueMember = "GameID";
		}

		private void btnChooseGame_Click(object sender, EventArgs e)
		{
			LoadCommandsForGame();
		}

		private void LoadCommandsForGame()
		{
			var gameId = (Guid) ddlGames.SelectedValue;

			var commandActions = from ca in _dataContext.CommandActions
			                     where gameId == Guid.Empty || ca.GameID == gameId
			                     select
				                     new
					                     {
						                     CommandActionID = ca.CommandActionID,
						                     CommandTypeName = ca.Command.CommandType.CommandTypeName
					                     };

			ddlCommand.DataSource = commandActions.ToList();
			ddlCommand.DisplayMember = "CommandTypeName";
			ddlCommand.ValueMember = "CommandActionID";

		}

		private void ddlCommand_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlCommand.SelectedValue is int)
			{ 
			var actions = from a in _dataContext.CommandActionActions
						  where a.CommandActionID == (int)ddlCommand.SelectedValue
						  orderby a.ActionOrder
						  select new { ActionID = a.ActionID, ActionName = a.Action.ActionName };

			lstActions.DataSource = actions;
			lstActions.DisplayMember = "ActionName";
			lstActions.ValueMember = "ActionID";
			}
		}
	}
}
