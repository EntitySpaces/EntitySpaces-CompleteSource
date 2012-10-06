/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EntitySpaces.AddIn
{
    internal partial class ucWhatsNew : esUserControl
    {
        bool showingNews = true;

        public ucWhatsNew()
        {
            InitializeComponent();
        }

        private void ucWhatsNew_Load(object sender, EventArgs e)
        {
            try
            {
                ScreenScrape();

                if (File.Exists(whatsNewFilePath))
                {
                    WhatsNewWebBrowser.Url = new Uri(whatsNewFilePath);
                }
            }
            catch { }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WhatsNewWebBrowser.DocumentTitle.StartsWith("Navigation"))
            {
                WhatsNewWebBrowser.Visible = false;
            }
        }

        public void ScreenScrape()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri("http://www.developer.entityspaces.net/documentation/WhatsNew.aspx"), this.WhatsNewWebBrowser);
            }
        }

        private static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                if (e.Error == null)
                {
                    if (!string.IsNullOrEmpty(e.Result))
                    {
                        File.WriteAllText(whatsNewFilePath, e.Result.Trim());
                    }
                }

                if (File.Exists(whatsNewFilePath))
                {
                    WebBrowser browser = e.UserState as WebBrowser;
                    browser.Url = new Uri(whatsNewFilePath);
                }
            }
            catch { }
        }

        private static string whatsNewFilePath
        {
            get
            {
                return string.Concat(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "\\EntitySpaces\\ES2012\\WhatsNew.html");
            }
        }

        private void toolStripHome_Click(object sender, EventArgs e)
        {
            try
            {
                showingNews = false;

                if (!this.toolStripEmbed.Checked)
                    System.Diagnostics.Process.Start("http://www.entityspaces.net/");
                else
                    WhatsNewWebBrowser.Navigate("http://www.entityspaces.net/");
            }
            catch { }
        }

        private void toolStripDocumentation_Click(object sender, EventArgs e)
        {
            try
            {
                showingNews = false;

                if (!this.toolStripEmbed.Checked)
                    System.Diagnostics.Process.Start("http://developer.entityspaces.net/documentation/");
                else
                    WhatsNewWebBrowser.Navigate("http://developer.entityspaces.net/documentation/");
            }
            catch { }
        }

        private void toolStripSupport_Click(object sender, EventArgs e)
        {
            try
            {
                showingNews = false;

                if (!this.toolStripEmbed.Checked)
                    System.Diagnostics.Process.Start("http://www.entityspaces.net/portal/Forums/tabid/203/Default.aspx");
                else
                    WhatsNewWebBrowser.Navigate("http://www.entityspaces.net/portal/Forums/tabid/203/Default.aspx");
            }
            catch { }
        }

        private void toolStripBlog_Click(object sender, EventArgs e)
        {
            try
            {
                showingNews = false;

                if (!this.toolStripEmbed.Checked)
                    System.Diagnostics.Process.Start("http://www.entityspaces.net/blog/");
                else
                    WhatsNewWebBrowser.Navigate("http://www.entityspaces.net/blog/");
            }
            catch { }
        }

        private void toolStripTwitter_Click(object sender, EventArgs e)
        {
            try
            {
                showingNews = false;

                if (!this.toolStripEmbed.Checked)
                    System.Diagnostics.Process.Start("http://twitter.com/entityspaces/");
                else
                    WhatsNewWebBrowser.Navigate("http://twitter.com/entityspaces/");
            }
            catch { }
        }

        private void toolStripWhatsNew_Click(object sender, EventArgs e)
        {
            showingNews = true;

            WhatsNewWebBrowser.Navigate("http://www.developer.entityspaces.net/documentation/WhatsNew.aspx");
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            if (showingNews)
            {
                ScreenScrape();
            }
            else
            {
                WhatsNewWebBrowser.Refresh();
            }
        }
    }
}
