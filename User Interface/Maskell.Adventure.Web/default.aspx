<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Maskell.Adventure.Web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script src="Assets/JavaScript/jquery-1.7.min.js" type="text/javascript"></script>
	<script type="text/javascript">

		$(document).ready(function () {

			$("#txtCommand").focus();

		});
	
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<h3>
			<asp:Literal ID="ltlGameTitle" runat="server"></asp:Literal></h3>
		<asp:Panel ID="pnlGameInfo" runat="server">
			<p id="gameDescription">
				<asp:Literal ID="ltlGameDescription" runat="server"></asp:Literal></p>
			<p>
				<asp:Button ID="btnStart" runat="server" Text="Start Game" OnClick="btnStart_Click" /></p>
		</asp:Panel>
		<asp:Panel ID="pnlGame" runat="server" Visible="false">
			<p id="locationDescription">
				<asp:Literal ID="ltlLocationDescription" runat="server"></asp:Literal></p>
			<p id="CommandResponseMessage">
				<asp:Literal ID="ltlCommandResponseMessage" runat="server"></asp:Literal></p>
			<asp:Panel ID="pnlCommand" runat="server" DefaultButton="btnExecuteCommand">
				<p>
					<asp:TextBox ID="txtCommand" ClientIDMode="Static" runat="server"></asp:TextBox>
					<asp:Button ID="btnExecuteCommand" runat="server" Text="Go" OnClick="btnExecuteCommand_Click" /></p>
			</asp:Panel>
		</asp:Panel>
	</div>
	</form>
</body>
</html>
