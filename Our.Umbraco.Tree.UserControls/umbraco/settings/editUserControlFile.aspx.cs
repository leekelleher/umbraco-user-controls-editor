using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco;
using umbraco.BasePages;

namespace Our.Umbraco.Tree.UserControls.umbraco.settings
{
	public partial class editUserControlFile : UmbracoEnsuredPage
	{
		internal const string UC_PATH = "/usercontrols/";

		protected override void OnInit(EventArgs e)
		{
			var button = this.Panel1.Menu.NewImageButton();
			button.Click += new ImageClickEventHandler(this.Save_Click);
			button.AlternateText = "Save User Control File";
			button.ImageUrl = string.Concat(GlobalSettings.Path, "/images/editor/save.gif");

			base.OnInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var fileName = Request.QueryString["file"];
			this.NameTxt.Text = fileName;

			var applicationPath = Request.ApplicationPath;
			if (applicationPath == "/")
			{
				applicationPath = string.Empty;
			}

			this.lttPath.Text = string.Concat(applicationPath, UC_PATH, fileName);

			if (!IsPostBack && Server.MapPath(string.Concat(UC_PATH, fileName)).StartsWith(Server.MapPath(UC_PATH)))
			{
				using (var reader = File.OpenText(Server.MapPath(string.Concat(UC_PATH, fileName))))
				{
					var contents = reader.ReadToEnd();

					if (!string.IsNullOrEmpty(contents))
						this.editorSource.Text = contents;
				}
			}

			this.Panel1.Text = "Edit User Control File";
			this.pp_name.Text = "Name";
			this.pp_path.Text = "Path";
		}

		private void Save_Click(object sender, ImageClickEventArgs e)
		{
			if (this.SaveUserControlFile(this.NameTxt.Text, Request.QueryString["file"], this.editorSource.Text))
			{
				ClientTools.ShowSpeechBubble(speechBubbleIcon.save, ui.Text("speechBubbles", "fileSavedHeader"), string.Empty);
			}
			else
			{
				ClientTools.ShowSpeechBubble(speechBubbleIcon.save, ui.Text("speechBubbles", "fileErrorHeader"), ui.Text("speechBubbles", "fileErrorText"));
			}
		}

		public bool SaveUserControlFile(string filename, string oldName, string contents)
		{
			try
			{
				if (base.Server.MapPath(string.Concat(UC_PATH, filename)).StartsWith(Server.MapPath(UC_PATH)))
				{
					using (var writer = File.CreateText(Server.MapPath(string.Concat(UC_PATH, filename))))
					{
						writer.Write(contents);
					}

					if ((filename != oldName) && File.Exists(Server.MapPath(string.Concat(UC_PATH, oldName))))
					{
						File.Delete(Server.MapPath(string.Concat(UC_PATH, oldName)));
					}

					return true;
				}
			}
			catch
			{
			}

			return false;
		}
	}
}