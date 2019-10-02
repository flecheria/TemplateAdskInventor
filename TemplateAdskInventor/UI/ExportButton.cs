//////////////////////////////////////////////////////////////////////
//
// DO NOT CANCEL THIS PART
// Author: Paolo Cappelletto
// e-mail: p.cappelletto@maffeis.it
// skype4B: p.cappelletto@maffeis.it
//
// Copyright:
// Maffeis Enginnering
// Via Mignano 26 
// 36020 Solagna (VI) - ITALY
// http://www.maffeis.it/ - info@maffeis.it
//
//////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using Inventor;

namespace TemplateAdskInventor.UI
{
    public class ExportButton : Button
    {

        public ExportButton(Inventor.Application app,
            string displayName,
            string internalName,
            CommandTypesEnum commandType,
            string clientId,
            string description,
            string tooltip,
            object standardIcon,
            object largeIcon,
            ButtonDisplayEnum buttonDisplayType) :
            base(app, displayName, internalName, commandType, clientId, description, tooltip, standardIcon, largeIcon, buttonDisplayType)
        { }

        protected override void Button_OnExecute(NameValueMap Context)
        {
            try
            {
                MessageBox.Show("Hello from Test");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
