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
