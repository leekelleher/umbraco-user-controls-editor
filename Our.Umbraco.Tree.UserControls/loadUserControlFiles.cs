using System;
using System.Collections.Generic;
using System.Text;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace Our.Umbraco.Tree.UserControls
{
	public class loadUserControlFiles : FileSystemTree
	{
		protected override String FilePath
		{
			get
			{
				return "/usercontrols/";
			}
		}

		protected override String FileSearchPattern
		{
			get
			{
				return "*.ascx";
			}
		}

		public loadUserControlFiles(String application) : base(application) { }

		protected override void CreateRootNode(ref XmlTreeNode rootNode)
		{
			rootNode.Icon = "folder.gif";
			rootNode.OpenIcon = "folder_o.gif";
			rootNode.NodeType = "init" + this.TreeAlias;
			rootNode.NodeID = "init";
			rootNode.Menu = new List<IAction>();
		}

		protected override void OnRenderFileNode(ref XmlTreeNode xNode)
		{
			xNode.Action = xNode.Action.Replace("openFile", "openUserControlEditor");
			xNode.Menu = new List<IAction>();
			xNode.Icon = "settingXML.gif";
			xNode.OpenIcon = "settingXML.gif";
		}

		protected override void OnRenderFolderNode(ref XmlTreeNode xNode)
		{
			xNode.Menu = new List<IAction>(new IAction[] { ActionRefresh.Instance });
			xNode.NodeType = "usercontrolsFolder";
		}

		public override void RenderJS(ref StringBuilder Javascript)
		{
			Javascript.Append(@"
				function openUserControlEditor(id) {
					parent.right.document.location.href = 'settings/editUserControlFile.aspx?file=' + id;
				}
			");
		}
	}
}