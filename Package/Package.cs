/*
***********************************************
*  Copyright (c), Skyline Communications NV.  *
***********************************************

Revision History:

DATE		VERSION		AUTHOR			COMMENTS

29/12/2025	1.0.0.1		, Skyline	Initial version
****************************************************************************
*/

using System;

using Skyline.AppInstaller;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.AppPackages;
using Skyline.DataMiner.Net.ServiceManager.Objects;

using SLNetMessages = Skyline.DataMiner.Net.Messages;
/// <summary>
/// DataMiner Script Class.
/// </summary>
internal class Script
{
	/// <summary>
	/// The script entry point.
	/// </summary>
	/// <param name="engine">Provides access to the Automation engine.</param>
	/// <param name="context">Provides access to the installation context.</param>
	[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
	public void Install(IEngine engine, AppInstallContext context)
	{
		try
		{
			engine.Timeout = new TimeSpan(0, 10, 0);
			engine.GenerateInformation("Starting installation");
			var installer = new AppInstaller(Engine.SLNetRaw, context);
			installer.InstallDefaultContent();

			////string setupContentPath = installer.GetSetupContentDirectory();

			SLNetMessages.SetScriptMemoryValuesMessage setMemoryMessage = new SLNetMessages.SetScriptMemoryValuesMessage
			{
				Name = "View Input Type",
				Values = new SLNetMessages.ScriptMemoryValue[]
				{
					new SLNetMessages.ScriptMemoryValue()
					{
						Position = 0,
						Description = "Name of View",
						Value = new SLNetMessages.ParameterValue
						{
							ValueType = SLNetMessages.ParameterValueType.String,
							StringValue = "Name",
							DoubleValue = 0,
						},
					},
					new SLNetMessages.ScriptMemoryValue()
					{
						Position = 1,
						Description = "ID of View",
						Value = new SLNetMessages.ParameterValue
						{
							ValueType = SLNetMessages.ParameterValueType.String,
							StringValue = "ID",
							DoubleValue = 1,
						},
					},
				},
			};

			try
			{
				SLNetMessages.SetScriptMemoryValuesMessage resp = engine.SendSLNetSingleResponseMessage(setMemoryMessage) as SLNetMessages.SetScriptMemoryValuesMessage;
							}
			catch (Exception e )
			{
				engine.GenerateInformation($"Failed to set Script Memory Values: {e}");
			}
		}
		catch (Exception e)
		{
			engine.ExitFail($"Exception encountered during installation: {e}");
		}
	}
}
