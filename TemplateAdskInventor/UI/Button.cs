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

using Inventor;
using System;
using System.Diagnostics;

namespace TemplateAdskInventor.UI
{
    public abstract class Button
    {
        private ButtonDefinition _buttonDefinition;
        private ButtonDefinitionSink_OnExecuteEventHandler _buttonDef_OnExecuteEventDelegate;

        #region CONSTRUCTOR

        /// <summary>
        /// Create a button from inventor using Image file as icon
        /// </summary>
        /// <param name="app"></param>
        /// <param name="displayName"></param>
        /// <param name="internalName"></param>
        /// <param name="commandType"></param>
        /// <param name="clientId"></param>
        /// <param name="description"></param>
        /// <param name="tooltip"></param>
        /// <param name="standardIcon"></param>
        /// <param name="largeIcon"></param>
        /// <param name="buttonDisplayType"></param>
        public Button(Inventor.Application app,
                       string displayName,
                       string internalName,
                       CommandTypesEnum commandType,
                       string clientId,
                       string description,
                       string tooltip,
                       object standardIcon,
                       object largeIcon,
                       ButtonDisplayEnum buttonDisplayType)
        {

            try
            {
                _buttonDefinition = app.CommandManager
                    .ControlDefinitions
                    .AddButtonDefinition(displayName,
                                         internalName,
                                         commandType,
                                         clientId,
                                         description,
                                         tooltip,
                                         standardIcon,
                                         largeIcon,
                                         buttonDisplayType);

                _buttonDefinition.Enabled = true;
                _buttonDef_OnExecuteEventDelegate = new ButtonDefinitionSink_OnExecuteEventHandler(Button_OnExecute);
                _buttonDefinition.OnExecute += _buttonDef_OnExecuteEventDelegate;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new ApplicationException(ex.Message);
            }
        }

        #endregion

        public ButtonDefinition ButtonDefinition
        {
            get { return _buttonDefinition; }
        }

        protected abstract void Button_OnExecute(NameValueMap context);

    }
}
