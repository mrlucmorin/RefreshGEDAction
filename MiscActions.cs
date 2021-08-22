/*
Luc Morin, 2021

Misc. Actions

Load the script in Eplan (don't "run" it).

*/

/*
The following compiler directive is necessary to enable editing scripts
within Visual Studio.

It requires that the "Conditional compilation symbol" SCRIPTENV be defined 
in the Visual Studio project properties

This is because EPLAN's internal scripting engine already adds "using directives"
when you load the script in EPLAN. Having them twice would cause errors.
*/

//#if SCRIPTENV
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.Base;
using Eplan.EplApi.Gui; 
//#endif

/*
On the other hand, some namespaces are not automatically added by EPLAN when
you load a script. Those have to be outside of the previous conditional compiler directive
*/

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic; 
using System.Linq;

using Action = Eplan.EplApi.ApplicationFramework.Action;
using Menu = Eplan.EplApi.Gui.Menu;

public class MiscActions
{
	[DeclareAction("RefreshGEDAction")]
	public void RefreshGEDAction()
	{
		//http://www.stlm.ca/blog/?cat=9
		
		//Refresh the GED
		EventParameterString oEventParamString = new EventParameterString();
		oEventParamString.String = "";
		int result = new EventManager().Send("PageManagement.ProjectSettings.Changed", oEventParamString);
		
	}
	
}

#region WindowWrapper class
//Singleton code taken from https://csharpindepth.com/articles/singleton
public sealed class WindowWrapper : System.Windows.Forms.IWin32Window
{
    private static readonly Lazy<WindowWrapper> lazy = new Lazy<WindowWrapper>(() => new WindowWrapper());
    private WindowWrapper() 
    {
        Handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
    }

    public static WindowWrapper Instance { get { return lazy.Value; } }

    public IntPtr Handle { get; private set; }
}

#endregion
