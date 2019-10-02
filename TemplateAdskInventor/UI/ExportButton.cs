//////////////////////////////////////////////////////////////////////
//
// DO NOT CANCEL THIS PART
// Author: Paolo Cappelletto a.k.a. flecheria
//
//Copyright(c) 2019 Paolo Cappelletto
//
// MIT license
//
//Permission is hereby granted, free of charge, to any person
//obtaining a copy of this software and associated documentation
//files (the "Software"), to deal in the Software without
//restriction, including without limitation the rights to use,
//copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the
//Software is furnished to do so, subject to the following
//conditions:
//
//The above copyright notice and this permission notice shall be
//included in all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//OTHER DEALINGS IN THE SOFTWARE.
//////////////////////////////////////////////////////////////////////
///
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
