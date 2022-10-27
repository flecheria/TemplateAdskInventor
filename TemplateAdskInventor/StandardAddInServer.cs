//////////////////////////////////////////////////////////////////////
//
// DO NOT CANCEL THIS PART
// Author: Paolo Cappelletto a.k.a. flecheria
//
//Copyright(c) $year$ Paolo Cappelletto
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

using System;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using System.Drawing;
using $safeprojectname$.UI;
using System.Windows.Forms;
using System.Diagnostics;

namespace $safeprojectname$
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("$guid1$")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {
        // Inventor application object.
        private Inventor.Application _app;

        private bool _isAuthorize;
        private string _addInGuid;
        private string _panelDisplayName = "$safeprojectname$";

        #region UI

        private object _exportPict;

        protected CommandManager _cmdMan;
        protected CommandCategory _cmdCat;
        protected ButtonDefinition _exportBtnDef;

        protected RibbonPanel _startedPanel;
        //protected RibbonPanel _partPanel;
        //protected RibbonPanel _assemblyPanel;
        //protected RibbonPanel _drawingPanel;

        #endregion

        public StandardAddInServer()
        {
            _isAuthorize = false;
            _addInGuid = "{$guid1$}";
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            // authorization procedure
            _isAuthorize = true;

            if (_isAuthorize)
            {
                // Initialize AddIn members.
                _app = addInSiteObject.Application;

                #region UI INIT

                Image exportImg = $safeprojectname$.Properties.Resources.Button;
                _exportPict = ImageConversion.ImageToPictureDisp(exportImg);

                // get command manager
                _cmdMan = _app.CommandManager;

                // defne comand catagory for addin buttons
                _cmdCat = _cmdMan.CommandCategories.Add(
                    _panelDisplayName, "flecheria:CmdCategory:$safeprojectname$",
                    _addInGuid);

                ControlDefinitions ctrlDefs = _app.CommandManager.ControlDefinitions;

                try
                {
                    _exportBtnDef = ctrlDefs["flecheria:$safeprojectname$:TestButton"] as ButtonDefinition;
                }
                catch (Exception ex)
                {
                    #region BUTTON CREATION

                    ExportButton exportBtn = new ExportButton(_app,
                        "Export Obj", "flecheria:$safeprojectname$:ExportObj",
                        CommandTypesEnum.kQueryOnlyCmdType, _addInGuid,
                        "Export Obj with data",
                        "Export Obj with data and tree information",
                        _exportPict, _exportPict,
                        ButtonDisplayEnum.kAlwaysDisplayText);
                    _exportBtnDef = exportBtn.ButtonDefinition;
                    _cmdCat.Add(_exportBtnDef);

                    #endregion

                    Debug.WriteLine(ex.Message);
                }

                // create panel interface
                if (firstTime)
                {
                    try
                    {
                        if (_app.UserInterfaceManager.InterfaceStyle == InterfaceStyleEnum.kRibbonInterface)
                        {
                            #region RIBBON AND PANELS

                            // getting ribbons
                            Ribbon startedRib = _app.UserInterfaceManager.Ribbons["ZeroDoc"];
                            //Ribbon partRib = _app.UserInterfaceManager.Ribbons["Part"];
                            //Ribbon assemblyRib = _app.UserInterfaceManager.Ribbons["Assembly"];
                            //Ribbon drawingRib = _app.UserInterfaceManager.Ribbons["Drawing"];

                            // getting tab
                            RibbonTab startedTab = startedRib.RibbonTabs["id_GetStarted"];
                            //RibbonTab partTab = partRib.RibbonTabs["id_AddInsTab"];
                            //RibbonTab assemblyTab = assemblyRib.RibbonTabs["id_AddInsTab"];
                            //RibbonTab drawingTab = drawingRib.RibbonTabs["id_AddInsTab"];

                            _startedPanel = startedTab.RibbonPanels.Add(_panelDisplayName,
                                "flecheria:$safeprojectname$:AOEPanelStart", _addInGuid, "", false);
                            //_partPanel = partTab.RibbonPanels.Add(_panelDisplayName,
                            //    "flecheria:$safeprojectname$:AOEPanelPart", _addInGuid, "", false);
                            //_assemblyPanel = assemblyTab.RibbonPanels.Add(_panelDisplayName,
                            //    "flecheria:$safeprojectname$:AOEPanelAssembly", _addInGuid, "", false);
                            //_drawingPanel = drawingTab.RibbonPanels.Add(_panelDisplayName,
                            //    "flecheria:$safeprojectname$:AOEPanelDrawing", addInGuid, "", false);

                            #endregion

                            #region CREATE BUTTON ON STARTED TAB

                            CommandControl startExportControl = _startedPanel.CommandControls.AddButton(
                                _exportBtnDef, false, true, "", true);

                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "$safeprojectname$ Error");
                        Debug.Write(ex.Message);
                    }
                }

                #endregion
            }

        }

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated

            // TODO: Add ApplicationAddInServer.Deactivate implementation

            // Release objects.
            _app = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }

        #endregion

    }
}
