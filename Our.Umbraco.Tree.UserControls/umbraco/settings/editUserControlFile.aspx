<%@ Page Language="C#" MasterPageFile="../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editUserControlFile.aspx.cs" Inherits="Our.Umbraco.Tree.UserControls.umbraco.settings.editUserControlFile" ValidateRequest="False" %>
<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script src="../../js/prototype.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<cc1:UmbracoPanel ID="Panel1" runat="server" Width="608px" Height="336px" hasMenu="true">
		<cc1:Pane ID="Pane7" runat="server" Height="44px" Width="528px">
			<cc1:PropertyPanel runat="server" ID="pp_name">
				<asp:TextBox ID="NameTxt" Width="350px" runat="server"></asp:TextBox>
			</cc1:PropertyPanel>
			<cc1:PropertyPanel runat="server" id="pp_path">
				<asp:Literal ID="lttPath" runat="server"/>
			</cc1:PropertyPanel>
			<cc1:PropertyPanel ID="pp_source" runat="server">
				<cc1:CodeArea ID="editorSource" runat="server" AutoResize="true" OffSetX="47" OffSetY="47" />
			</cc1:PropertyPanel>
		</cc1:Pane>
	</cc1:UmbracoPanel>
</asp:Content>
